using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace php.helper
{
    class Keke_Content
    {
        public static string con = null;
        public static string php_start = "<?php defined ( 'IN_KEKE' ) or exit ( 'Access Denied' );\r\n ";
        public static string php_mem = "/** \r\n * @copyright keke-tech \r\n * @author Michaeltsui98 \r\n * @version 3.0 {0} \r\n */\r\n";

        
        //后台的php文件
        public static string getAdminPHP(List<obj_field> of,string cname,string tablename) {
            if (of == null) {
                return con;
            }
            
            php_mem = string.Format(php_mem, DateTime.Now);
            con += (php_start+php_mem);
            
            //表名要去掉前缀
            string table_name = tablename.Substring(tablename.IndexOf("_") + 1);
            string fn = cname.Substring(cname.LastIndexOf("_") + 1);
            string tpl_name = cname.Replace("_", "/");
            //主键
            string pk = of.First().field_name;

            StringBuilder sb = new StringBuilder();
            string class_name = "class Control_admin_{0} extends Control_admin{";

            class_name = class_name.Replace("{0}", cname);

            sb.AppendLine(class_name);
            //action_index
            sb.AppendLine("\tfunction action_index() {");

            List<string> fields = getSelectField(of);
            string fieldsString = string.Join(",", fields.ToArray());
            sb.AppendLine("\t\t$fidlds='"+fieldsString+"';");
                    
            List<string> querys = getQueryField(of);
            string querysString = string.Join(",", querys.ToArray());
            sb.AppendLine("\t\t$query_fields = array(" + querysString + ");");
            sb.AppendFormat("\t\t$base_uri = BASE_URL.\"/index.php/admin/{0}\";", cname);
            sb.AppendLine("\r\t\t$add_uri =  $base_uri.'/add';");
            sb.AppendLine("\t\t$del_uri = $base_uri.'/del';");
            sb.AppendFormat("\t\t$this->_default_ord_field = '{0}';", of.First().field_name);
            sb.AppendLine("\r\t\textract($this->get_url($base_uri));");
            sb.AppendFormat("\t\t$data_info = Model::factory('{0}')->get_grid($fields,$where,$uri,$order);", table_name);
            sb.AppendLine("\r\t\t$list_arr = $data_info['data'];");
            sb.AppendLine("\t\t$pages = $data_info['pages']['page'];");
            sb.AppendFormat("\t\trequire Keke_tpl::template('control/admin/tpl/{0}');", tpl_name);
            sb.AppendLine("\r\t}");

            //action_ add 添加与编辑初始化
            sb.AppendLine("\tfunction action_add(){");
            string add_1 = "\t\tif(isset($_GET['{0}'])){";
            add_1 = add_1.Replace("{0}", of.First().field_name);
            sb.AppendLine(add_1);
            sb.AppendFormat("\t\t\t${0} = $_GET['{0}'];\r", of.First().field_name);
            sb.AppendFormat("\t\t\t$info = DB::select()->from('{0}')->where(\"{1} = '${1}'\")->get_one()->execute();\r",table_name,of.First().field_name);
            sb.AppendLine("\t\t}");
            sb.AppendFormat("\t\trequire Keke_tpl::template('control/admin/tpl/{0}');\r",tpl_name+"_add");
            sb.AppendLine("\t}");
            //add_end
            
            //action_save
            List<string> edit = getSaveField(of);
            string arr = string.Join(",\r\t\t\t\t\t", edit.ToArray());
            sb.AppendLine("\tfunction action_save(){");
            sb.AppendLine("\t\t$_POST = Keke_tpl::chars($_POST);");
            sb.AppendLine("\t\tKeke::formcheck($_POST['formhash']);");
            sb.AppendLine(string.Format("\t\t$arr = array({0});",arr));
            sb.AppendLine("\t\tif($_POST['hdn_{0}']){".ToString().Replace("{0}",pk));
            sb.AppendLine("\t\t\t$where = \"{0} ='{$_POST['hdn_{0}']}'\";".ToString().Replace("{0}",pk));
            sb.AppendLine(string.Format("\t\t\tDB::update('{0}')->set(array_keys($arr))->value(array_values($arr))->where($where)->execute();",table_name));
            sb.AppendLine(string.Format("\t\t\t$this->request->redirect('admin/{0}/add?{1}='.$_POST['hdn_{1}']);",cname,pk));
            sb.AppendLine("\t\t}else{");
            sb.AppendLine(string.Format("\t\t\tDB::insert('{0}')->set(array_keys($arr))->value(array_values($arr))->execute();",table_name));
            sb.AppendLine(string.Format("\t\t\t$this->request->redirect('admin/{0}/add');",cname));
            sb.AppendLine("\t\t}");
            sb.AppendLine("\t}");
            //save_end


            //action_del  删除
            sb.AppendLine("\tfunction action_del(){");
            sb.AppendLine("\t\tif(isset($_GET['"+pk+"'])){ ");
            sb.AppendLine("\t\t\t$where = \""+pk+" = '{$_GET['"+pk+"']}'\";");
            sb.AppendLine("\t\t}elseif(isset($_GET['ids'])){");
            sb.AppendLine("\t\t\t$where = \"" + pk + " in ('{$_GET['ids']}')\"; ");
            sb.AppendLine("\t\t}");
            sb.AppendLine(string.Format("\t\techo DB::delete('{0}')->where($where)->execute();",table_name));
            sb.AppendLine("\t}");
            //del_end



            sb.AppendLine("}");
            string c = con + sb.ToString();
            con = null;
            return c;
        }
       

        public static string getAdminHtml(List<obj_field> of, string cname, string tablename)
        {
           if (of == null){
                return con;
            }
           // php_mem = string.Format(php_mem, DateTime.Now);
            //con += (php_start + php_mem);

            //表名要去掉前缀
            string table_name = tablename.Substring(tablename.IndexOf("_") + 1);

            string tpl_name = cname.Replace("_", "/");
            //主键
            string pk = of.First().field_name;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!--{include control/admin/tpl/admin_header}-->");
            sb.AppendLine("<div class=\"page_title\">");
            sb.AppendLine(String.Format("\t<h1>{0}</h1>",table_name));
            sb.AppendLine("\t<div class=\"tool\"> ");
            sb.AppendLine("\t\t<a href=\"{BASE_URL}/index.php/admin/{0}\" {if $_K['action'] != 'add'}class=\"here\"{/if}>{$_lang['list']}</a>".ToString().Replace("{0}",cname));
            sb.AppendLine("\t\t<a href=\"{BASE_URL}/index.php/admin/"+cname+"/add\" {if $_K['action'] == 'add'}class=\"here\"{/if}>{if $"+pk+"}{$_lang['edit']}{else}{$_lang['add']}{/if}</a>");
            sb.AppendLine("\t</div>");
            sb.AppendLine("</div>");

            sb.AppendLine("<div class=\"box search\">");
            sb.AppendLine("<form method=\"get\" action=\"{BASE_URL}/index.php/admin/"+cname+"\" >");
            sb.AppendLine("\t<!--{include control/admin/tpl/search}-->");
            sb.AppendLine("</form>");
            sb.AppendLine("</div>");

            sb.AppendLine("<div class=\"box list\">");
            sb.AppendLine("<table class=\"detail\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
            sb.AppendLine("\t<tr>");

            List<string> order = getSelectField(of, true);
            string order_str = string.Join("\r\t\t", order.ToArray());
            sb.AppendLine("\t\t"+order_str);

            sb.AppendLine("\t\t<th width=\"60\">{$_lang['operate']}</th>");
            sb.AppendLine("\t</tr>");

            sb.AppendLine("\t{loop $list_arr $k $v}");
            sb.AppendLine("\t <tr class=\"item\">");
            List<string> list = getSelectField(of, "list");
            string list_str = string.Join("\r\t\t", list.ToArray());
            sb.AppendLine(list_str);
            sb.AppendLine("\t\t<td>");
            sb.AppendLine("\t\t\t<a href=\"{$add_uri}?"+pk+"={$v['"+pk+"']}\" class=\"button dbl_target\">{$_lang['edit']}</a>");
            sb.AppendLine("\t\t\t<a href=\"{$del_uri}?" + pk + "={$v['" + pk + "']}\" onclick=\"return cdel(this);\" class=\"button\">{$_lang['delete']}</a>");
            sb.AppendLine("\t\t</td>");
            sb.AppendLine("\t</tr>");
            sb.AppendLine("\t{/loop}");
            sb.AppendLine("\t<tfoot>");
            sb.AppendLine("\t\t<tr>");
            sb.AppendLine("\t\t\t<td colspan=\""+(of.Count+1)+"\">");
            sb.AppendLine("\t\t\t\t<div class=\"page\">{$pages}</div>");
            sb.AppendLine("\t\t\t\t<input type=\"checkbox\" onclick=\"checkall(event);\" id=\"checkbox\" name=\"checkbox\"/>");
            sb.AppendLine("\t\t\t\t<label for=\"checkbox\"> {$_lang['select_all']}</label>");
            sb.AppendLine("\t\t\t\t<button type=\"submit\" name=\"sbt_action\" onclick=\"return batch_act(this)\" value=\"{$_lang['mulit_delete']}\">");
            sb.AppendLine("\t\t\t\t{$_lang['mulit_delete']}");
            sb.AppendLine("\t\t\t\t</button>");
            sb.AppendLine("\t\t\t</td>");
            sb.AppendLine("\t\t</tr>");
            sb.AppendLine("\t</tfoot>");
            sb.AppendLine("</table>");
            sb.AppendLine("</div>");
            sb.AppendLine("<!--{include control/admin/tpl/admin_footer}-->");

            string c = con + sb.ToString();
            con = null;
            return c;
        
        }
        public static string getAdminEditHtml(List<obj_field> of, string cname, string tablename)
        {
            if (of == null)
            {
                return con;
            }
            
            //表名要去掉前缀
            string table_name = tablename.Substring(tablename.IndexOf("_") + 1);

            string tpl_name = cname.Replace("_", "/");
            //主键
            string pk = of.First().field_name;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!--{include control/admin/tpl/admin_header}-->");
            sb.AppendLine("<div class=\"page_title\">");
            sb.AppendLine(String.Format("\t<h1>{0}</h1>", table_name));
            sb.AppendLine("\t<div class=\"tool\"> ");
            sb.AppendLine("\t\t<a href=\"{BASE_URL}/index.php/admin/{0}\" {if $_K['action'] != 'add'}class=\"here\"{/if}>{$_lang['list']}</a>".ToString().Replace("{0}", cname));
            sb.AppendLine("\t\t<a href=\"{BASE_URL}/index.php/admin/" + cname + "/add\" {if $_K['action'] == 'add'}class=\"here\"{/if}>{if $" + pk + "}{$_lang['edit']}{else}{$_lang['add']}{/if}</a>");
            sb.AppendLine("\t</div>");
            sb.AppendLine("</div>");



            sb.AppendLine("<div class=\"box post detail\">");
            sb.AppendLine("<form method=\"post\" action=\"{BASE_URL}/index.php/admin/"+cname+"/save\" onsubmit=\"return checkForm(this)\" id=\"frm_"+table_name+"\" enctype=\"multipart/form-data\">");
            sb.AppendLine("\t<input type=\"hidden\" name=\"hdn_" + pk + "\" value=\"{$info['" + pk + "']}\">");
            sb.AppendLine("\t<input type=\"hidden\" name=\"formhash\" value=\"{FORMHASH}\"/>");
            sb.AppendLine("\t<table  border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
            List<string> edit = getEditField(of);
            string edit_str = string.Join("\r", edit.ToArray());
            sb.AppendLine(edit_str);

            
            sb.AppendLine("\t<tr>");
            sb.AppendLine("\t\t<th scope=\"row\"></th>");
            sb.AppendLine("\t\t<td>");
            sb.AppendLine("\t\t\t<input type=\"submit\" value=\"{$_lang['submit']}\">");
            sb.AppendLine("\t\t\t<input type=\"button\" value=\"{$_lang['return']}\"onclick=\"to_back()\">");
            sb.AppendLine("\t\t</td>");
            sb.AppendLine("\t</tr>");

            sb.AppendLine("\t</table>");
            sb.AppendLine("</form>");
            sb.AppendLine("</div>"); 


            sb.AppendLine("<!--{include control/admin/tpl/admin_footer}-->");

            string c = con + sb.ToString();
            con = null;
            return c;

        }

        
        public static List<string> getEditField(List<obj_field> of)
        {
            

            List<string> select = new List<string>();
            foreach (obj_field o in of)
            {
                if (o.edit == true)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("\t<tr>");
                    sb.AppendLine("\t\t<th width=\"150\" scope=\"row\">");
                    sb.AppendLine("\t\t\t"+o.as_name);
                    sb.AppendLine("\t\t</th>");
                    sb.AppendLine("\t\t<td>");
                    sb.AppendLine("\t\t<input type=\"text\" class=\"txt\" style=\"width:260px;\" name=\"txt_"+o.field_name+"\"");
                    sb.AppendLine("\t\tvalue=\"{$info['"+o.field_name+"']}\"");
                    sb.AppendLine("\t\tmaxlength=\""+o.size+"\" limit=\"required:true;len:1-"+o.size+"\"");
                    sb.AppendLine("\t\tmsg=\"not_empty\" msgArea=\""+o.field_name+"_msg\"");
                    sb.AppendLine("\t\tclass=\"input_t\"/>");
                    sb.AppendLine("\t\t<b style=\"color:red\">*</b>");
                    sb.AppendLine("\t\t<span id=\""+o.field_name+"_msg\"></span>");
                    
                    sb.AppendLine("\t\t</td>");
                    sb.AppendLine("\t</tr>");

                    select.Add(sb.ToString());
                }
            }
            return select;
        }

        public static List<string> getSelectField(List<obj_field> of,bool order)
        {
            List<string> select = new List<string>();
            float f =  100 /(of.Count + 1);
            int size = int.Parse(Math.Round(f,0).ToString());
            //int csize = 60;
            //foreach (obj_field o in of) {
             //   csize += int.Parse(o.size.ToString());
           // }

            foreach (obj_field o in of)
            {
                if (o.select == true)
                {
                    //float s = float.Parse(o.size.ToString());
                    //double f = Math.Round(s/csize*100,0);
                    select.Add("<th width=\""+size+"%\"><a href=\"javascript:;\" onclick=\"submitSort('{$uri}','"+o.field_name+"',{$ord_tag})\">"+o.as_name+"{if $_GET['f']=='"+o.field_name+"'}{$ord_char}{/if}</a></th>");
                }
            }
            return select;
        }
        public static List<string> getSelectField(List<obj_field> of,string list)
        {
            List<string> select = new List<string>();
            obj_field f = of.First();
            select.Add("\t\t<td><input type=\"checkbox\" name=\"ckb[]\" class=\"checkbox\" value=\"{$v['" + f.field_name + "']}\"> {$v['" + f.field_name + "']}</td>");
            
            for (int i = 0; i < of.Count; i++) {
                if (i > 0) {
                    if (of[i].select == true) {
                        select.Add("<td>{$v['" + of[i].field_name + "']}</td>");
                    }
                }
            }

            return select;
        }

        public static List<string> getSelectField(List<obj_field> of)
        {
            List<string> select = new List<string>();
            foreach (obj_field o in of)
            {
                if (o.select == true)
                {
                    select.Add("`" + o.field_name + "`");
                }
            }
            return select;
        }

        public static List<string> getQueryField(List<obj_field> of)
        {
            List<string> query = new List<string>();
            foreach (obj_field o in of)
            {
                if (o.search == true)
                {
                    query.Add("'" + o.field_name + "'" + "=>" + "'" + o.as_name + "'");
                }
            }
            return query;
        }
        public static List<string> getSaveField(List<obj_field> of)
        {
            List<string> edit = new List<string>();
            foreach (obj_field o in of)
            {
                if (o.edit == true)
                {
                    edit.Add("'" + o.field_name + "'" + "=>" + "$_POST['txt_" + o.field_name + "']");
                }
            }
            return edit;
        }


    }
}
