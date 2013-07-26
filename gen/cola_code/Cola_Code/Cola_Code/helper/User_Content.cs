using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace php.helper
{
    /// <summary>
    /// 用中心的数据生成
    /// </summary>
    class User_Content:Keke_Content
    {
        //一级菜单
       public static string one_menu = "";
        //二级菜单
       public static string two_menu = "";
        //默认排序字段
       public static string order_field = "";
        //多表的sql
       public static string sql = "";
        //多表的条件
       public static string where = "";
        //多表的分组
       public static string group_by = "";


        public static string getUserPHP(List<obj_field> of, string cname, string tablename)
        {
            if (of == null)
            {
                return con;
            }

            php_mem = string.Format(php_mem, DateTime.Now);
            con += (php_start + php_mem);
            //表名要去掉前缀
            string table_name = tablename.Substring(tablename.IndexOf("_") + 1);
            string fn = cname.Substring(cname.LastIndexOf("_") + 1);
            string tpl_name = cname.Replace("_", "/");
            //主键
            string pk = of.First().field_name;

            string class_name = "class Control_user_{0} extends Control_user{";
            //类名
            class_name = class_name.Replace("{0}", cname);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(class_name);

            

            sb.AppendLine(string.Format("\tprotected static $_default = '{0}';",one_menu));
            sb.AppendLine(string.Format("\tprotected static $_left = '{0}';",two_menu));
            //before()
            sb.AppendLine("\tfunction before(){");
		    sb.AppendLine("\t\tparent::before();");
		    sb.AppendLine("\t\tif(method_exists('Control_user_"+one_menu+"_index', 'init_nav')==true){");
			sb.AppendLine("\t\t\tControl_user_"+one_menu+"_index::init_nav();");
		    sb.AppendLine("\t\t}");
            sb.AppendLine("\t}");



            //action_index()
            sb.AppendLine("\tfunction action_index(){");
            //如果是多表就不需要这里
            if (string.IsNullOrEmpty(sql)) { 
                List<string> fields = getSelectField(of);
                string fieldsString = string.Join(",", fields.ToArray());
                sb.AppendLine("\t\t$fidlds='" + fieldsString + "';");
            }

            List<string> querys = getQueryField(of);
            string querysString = string.Join(",", querys.ToArray());
            sb.AppendLine("\t\t$query_fields = array(" + querysString + ");");

            sb.AppendFormat("\t\t$base_uri = USER_URL.\"/{0}\";", cname);
            sb.AppendLine("\r\t\t$add_uri =  $base_uri.'/add';");
            sb.AppendLine("\t\t$del_uri = $base_uri.'/del';");
            
            if(string.IsNullOrEmpty(sql))
            {
                sb.AppendFormat("\t\t$this->_default_ord_field = '{0}';", of.First().field_name);
            }else{
                sb.AppendFormat("\t\t$this->_default_ord_field = '{0}';", order_field);
            }

            if (string.IsNullOrEmpty(sql))
            {
                sb.AppendLine("\r\t\textract($this->get_url($base_uri));");
                sb.AppendFormat("\t\t$data_info = Model::factory('{0}')->get_grid($fields,$where,$uri,$order);", table_name);
            }
            else {
                string sqlStr = "\t\t$sql = "+sql+";";
                sb.AppendLine(sqlStr);
                sb.AppendLine("\r$sql = DB::query($sql)->tablepre(':keke_')->compile(Database::instance());");
                
                sb.AppendLine("\t\textract($this->get_url($base_uri));");

                if (string.IsNullOrEmpty(where) == false)
                {
                    sb.AppendLine(string.Format("\t\t$where .= \"{0}\";", where));
                }

                if (string.IsNullOrEmpty(group_by)==false) {
                    sb.AppendLine(string.Format("\t\t$group_by = {0}",group_by));
                }

                sb.AppendLine("\t\t$data_info = Model::sql_grid($sql,$where,$uri,$order,$group_by);");

            }
            
            sb.AppendLine("\r\t\t$list_arr = $data_info['data'];");
            sb.AppendLine("\t\t$pages = $data_info['pages']['page'];");
            sb.AppendFormat("\t\trequire Keke_tpl::template('user/{0}');", tpl_name);
            sb.AppendLine("\r\t}");
            //end action_index


            //action_ add 添加与编辑初始化
            sb.AppendLine("\tfunction action_add(){");
            string add_1 = "\t\tif(isset($_GET['{0}'])){";
            add_1 = add_1.Replace("{0}", of.First().field_name);
            sb.AppendLine(add_1);
            sb.AppendFormat("\t\t\t${0} = $_GET['{0}'];\r", of.First().field_name);
            sb.AppendFormat("\t\t\t$info = DB::select()->from('{0}')->where(\"{1} = '${1}'\")->get_one()->execute();\r", table_name, of.First().field_name);
            sb.AppendLine("\t\t}");
            sb.AppendFormat("\t\trequire Keke_tpl::template('user/{0}');\r",tpl_name + "_add");
            sb.AppendLine("\t}");
            //add_end

            //action_save
            List<string> edit = getSaveField(of);
            string arr = string.Join(",\r\t\t\t\t\t", edit.ToArray());
            sb.AppendLine("\tfunction action_save(){");
            sb.AppendLine("\t\t$_POST = Keke_tpl::chars($_POST);");
            sb.AppendLine("\t\tKeke::formcheck($_POST['formhash']);");
            sb.AppendLine(string.Format("\t\t$arr = array({0});", arr));
            sb.AppendLine("\t\tif($_POST['hdn_{0}']){".ToString().Replace("{0}", pk));
            sb.AppendLine("\t\t\t$where = \"{0} ='{$_POST['hdn_{0}']}'\";".ToString().Replace("{0}", pk));
            sb.AppendLine(string.Format("\t\t\tDB::update('{0}')->set(array_keys($arr))->value(array_values($arr))->where($where)->execute();", table_name));
            sb.AppendLine(string.Format("\t\t\t$this->request->redirect('user/{0}/add?{1}='.$_POST['hdn_{1}']);", cname, pk));
            sb.AppendLine("\t\t}else{");
            sb.AppendLine(string.Format("\t\t\tDB::insert('{0}')->set(array_keys($arr))->value(array_values($arr))->execute();", table_name));
            sb.AppendLine(string.Format("\t\t\t$this->request->redirect('user/{0}/add');", cname));
            sb.AppendLine("\t\t}");
            sb.AppendLine("\t}");
            //save_end


            //action_del  删除
            sb.AppendLine("\tfunction action_del(){");
            sb.AppendLine("\t\tif(isset($_GET['" + pk + "'])){ ");
            sb.AppendLine("\t\t\t$where = \"" + pk + " = '{$_GET['" + pk + "']}'\";");
            sb.AppendLine("\t\t}elseif(isset($_GET['ids'])){");
            sb.AppendLine("\t\t\t$where = \"" + pk + " in ('{$_GET['ids']}')\"; ");
            sb.AppendLine("\t\t}");
            sb.AppendLine(string.Format("\t\tDB::delete('{0}')->where($where)->execute();", table_name));
            sb.AppendLine("\t}");
            //del_end

            sb.Append("}");
            string c = con + sb.ToString();
            con = null;
            return c;
        }

        public static string getUserHtml(List<obj_field> of, string cname, string tablename)
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

            sb.AppendLine("<!--{include user/header}-->");
            sb.AppendLine("<div class=\"wrapper\">");
            sb.AppendLine("<article class=\"article container\">");
            sb.AppendLine("<!--{include user/"+one_menu+"/side}-->");
            sb.AppendLine("<div class=\"content\">");
            sb.AppendLine("<div class=\"box\">");
            sb.AppendLine("\t<div class=\"inner clearfix\">");

            sb.AppendLine("\t\t<header class=\"box_header\">");
            sb.AppendLine("\t\t\t<div class=\"box_title\">");
            sb.AppendLine(string.Format("\t\t\t<h2 class=\"title\">{0}</h2>",tablename));
            sb.AppendLine("\t\t\t</div>");
            sb.AppendLine("\t\t</header>");

            sb.AppendLine("\t\t<nav class=\"box_nav\">");
            sb.AppendLine("\t\t\t<ul id=\"test_ul\" class=\"clearfix\">");
            sb.AppendLine("\t\t\t\t<li class=\"selected\"><a href=\"{USER_URL}/" + cname + "\">列表</a></li>");
            sb.AppendLine("\t\t\t\t<li><a href=\"{USER_URL}/"+cname+"/add\">添加</a></li>");
            sb.AppendLine("\t\t\t</ul>");
            sb.AppendLine("\t\t</nav>");

            sb.AppendLine("\t\t<div class=\"box_detail\">");

            sb.AppendLine("\t\t\t<div class=\"toolbar\">");
            sb.AppendLine("\t\t\t\t<form class=\"detail\" action=\"{$base_uri}\" method=\"get\">");
            sb.AppendLine("\t\t\t\t\t<!--{include control/admin/tpl/search}-->");
            sb.AppendLine("\t\t\t\t</form>");
            sb.AppendLine("\t\t\t</div>");

            sb.AppendLine("\t\t\t<div class=\"data_list\">");
            sb.AppendLine("\t\t\t\t<table  class=\"data_table\">"); 
            sb.AppendLine("\t\t\t\t<thead>");
            sb.AppendLine("\t\t\t\t\t<tr>");

            List<string> order = getSelectField(of, true);
            string order_str = string.Join("\r\t\t", order.ToArray());
            sb.AppendLine("\t\t\t\t\t\t" + order_str);
            sb.AppendLine("\t\t\t\t\t\t</tr>");
            sb.AppendLine("\t\t\t\t\t</thead>");

            sb.AppendLine("\t\t\t\t\t<tbody>");
            sb.AppendLine("\t\t\t\t\t{if $list_arr}");
            sb.AppendLine("\t\t\t\t\t{loop $list_arr $k $v}");
            sb.AppendLine("\t\t\t\t\t<tr>");

            List<string> list = getSelectField(of, "list");
            string list_str = string.Join("\r\t\t", list.ToArray());

            sb.AppendLine(list_str);

            sb.AppendLine("\t\t\t\t\t</tr>");
            sb.AppendLine("\t\t\t\t\t{/loop}");
			sb.AppendLine("\t\t\t\t\t{else}");
			sb.AppendLine("\t\t\t\t\t<tfoot>");
	        sb.AppendLine("\t\t\t\t\t<tr>");
		    sb.AppendLine(string.Format("\t\t\t\t\t\t<td colspan=\"{0}\" class=\"t_c\">暂无记录</td>",of.Count));
		    sb.AppendLine("\t\t\t\t\t</tr>");
	        sb.AppendLine("\t\t\t\t\t</tfoot>");
            sb.AppendLine("\t\t\t\t\t{/if}");

            sb.AppendLine("\t\t\t\t</tbody>");
            sb.AppendLine("\t\t\t</table>");
            sb.AppendLine("\t\t</div>");
  
            sb.AppendLine("\t\t<div class=\"toolbar bottom\">");
            sb.AppendLine("\t\t\t<div class=\"actions\">");
            sb.AppendLine("\t\t\t\t<input type=\"button\" value=\"全选\" onclick=\"check_all();\">");
            sb.AppendLine("\t\t\t</div>");
            sb.AppendLine("\t\t\t<div class=\"page\">");
            sb.AppendLine("\t\t\t\t{$pages}");
            sb.AppendLine("\t\t\t</div>");
            sb.AppendLine("\t\t</div>");
            
    
            sb.AppendLine("\t\t</div>");
            sb.AppendLine("\t</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</article>");
            sb.AppendLine("</div>");


            sb.AppendLine("<script>");
            sb.AppendLine("\tfunction rm(o){");
            sb.AppendLine("\t\t$(o).parents('tr').remove();");
            sb.AppendLine("\t}");
            sb.AppendLine("</script>");

            sb.Append("<!--{include user/footer}-->");

            return sb.ToString();

        }
        public static string getUserEditHtml(List<obj_field> of, string cname, string tablename)
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

            sb.AppendLine("<!--{include user/header}-->");
            sb.AppendLine("<div class=\"wrapper\">");
            sb.AppendLine("<article class=\"article container\">");
            sb.AppendLine("<!--{include user/"+one_menu+"/side}-->");
            sb.AppendLine("<div class=\"content\">");
            sb.AppendLine("<div class=\"box\">");
            sb.AppendLine("\t<div class=\"inner clearfix\">");
            sb.AppendLine("\t\t<header class=\"box_header\">");
            sb.AppendLine("\t\t\t<div class=\"box_title\"");
            sb.AppendLine("\t\t\t<h2 class=\"title\">"+tablename+"</h2>");
            sb.AppendLine("\t\t</div>");
            sb.AppendLine("\t\t</header>");

            sb.AppendLine("\t\t<nav class=\"box_nav\">");
			sb.AppendLine("\t\t\t<ul id=\"test_ul\" class=\"clearfix\">");
			sb.AppendLine("\t\t\t\t<li><a href=\"{USER_URL}/"+cname+"\">列表</a></li>");
            sb.AppendLine("\t\t\t\t<li class=\"selected\"><a href=\"{USER_URL}/" + cname + "/add\" >添加</a></li>");
			sb.AppendLine("\t\t\t</ul>");
            sb.AppendLine("\t\t</nav>");

            sb.AppendLine("<div class=\"box_detail\">");
			sb.AppendLine("\t<form action=\"{$base_uri}/save\" method=\"post\" onsubmit=\"return checkForm(this)\" enctype=\"multipart/form-data\">");
			sb.AppendLine("\t<input type=\"hidden\" name=\"formhash\" value=\"{FORMHASH}\">");
			sb.AppendLine("\t<input type=\"hidden\" name=\"hdn_"+pk+"\" value=\"{$info['"+pk+"']}\">");

            List<string> edit = getEditField(of);
            string edit_str = string.Join("\r", edit.ToArray());
            sb.AppendLine(edit_str);
             

            sb.AppendLine("\t<div class=\"form_line\">");
    		sb.AppendLine("\t\t<hr>");
    		sb.AppendLine("\t</div>");

    		sb.AppendLine("\t<div class=\"form_footer\">");
    		sb.AppendLine("\t\t<input type=\"submit\" value=\"{$_lang['submit']}\" >");
    		sb.AppendLine("\t</div>");
			sb.AppendLine("\t</form>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</article>");
            sb.AppendLine("</div>");
    
            sb.AppendLine("<script type=\"text/jscript\"");
	        sb.AppendLine("\tIn('valid');");
            sb.AppendLine("</script>");
            sb.Append("<!--{include user/footer}-->");

            return sb.ToString() ;

        }
        public static List<string> getEditField(List<obj_field> of)
        {
            

            List<string> select = new List<string>();
            foreach (obj_field o in of)
            {
                if (o.edit == true)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("\t<div class=\"float_row\">");
    			    sb.AppendLine("\t\t<label class=\"form_label\">"+o.as_name+"：</label>");
				    sb.AppendLine("\t\t\t<div class=\"detail\">");
    			    sb.AppendLine("\t\t\t<input type=\"text\" name=\"txt_"+o.field_name+"\" value=\"{$info['"+o.field_name+"']}\"");
                    sb.AppendLine("\t\t\tmaxlength=\""+o.size+"\" limit=\"required:true;len:1-"+o.size+"\"");
				    sb.AppendLine("\t\t\ttitle=\"长度为"+o.size+"个字符\"");
				    sb.AppendLine("\t\t\tmsg=\"not empty!\"");
				    sb.AppendLine("\t\t\tmsgArea=\""+o.field_name+"_msg\" />");
    			    sb.AppendLine("\t\t\t<span id=\""+o.field_name+"_msg\"></span>");
				    sb.AppendLine("\t\t\t</div>");
			        sb.AppendLine("\t</div>");

                    select.Add(sb.ToString());
                }
            }
            return select;
        }

        public static List<string> getSelectField(List<obj_field> of, bool order)
        {
            List<string> select = new List<string>();
            float f = 100 / (of.Count);
            int size = int.Parse(Math.Round(f, 0).ToString());
            foreach (obj_field o in of)
            {
                if (o.select == true)
                {
                    select.Add("<th width=\"" + size + "%\"><a href=\"javascript:;\" onclick=\"submitSort('{$uri}','" + o.field_name + "',{$ord_tag})\">" + o.as_name + "{if $_GET['f']=='" + o.field_name + "'}{$ord_char}{/if}</a></th>");
                }
            }
            return select;
        }

       

    }
}
