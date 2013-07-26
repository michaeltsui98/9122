using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace php
{
    public partial class Form1 : Form
    {
        //连接mysql 数据库
        helper.MysqlUtil db = new helper.MysqlUtil();
        //字段列表对象
        public List<obj_field> fo = new List<obj_field>();
        public DataTable dts = new DataTable();
        public static List<string> dbs;
        public static string cname = "";
        public static string table = "";

        string version = "3.0";
       
        string company = "武汉客客威客系统服务商";
        public Form1()
        {
            InitializeComponent();
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            dbs =  db.openConn(txtHost.Text.ToString(), txtUid.Text.ToString(), txtPwd.Text.ToString());

            db_selet.DataSource = dbs;
            db_selet.DisplayMember = "Name";
        }
        //获取数据库的表信息
        private void db_selet_SelectedIndexChanged(object sender, EventArgs e)
        {
            string db_name = db_selet.SelectedValue.ToString();
            DataSet ds =  db.getTable(db_name);
            dts = ds.Tables[0];
            table_list.DataSource = ds.Tables[0];
            table_list.DisplayMember = ds.Tables[0].Columns[0].ToString();
            table_list.ValueMember = ds.Tables[0].Columns[0].ToString(); 
        }
        //获取表的字段信息
        private void table_list_Click(object sender, EventArgs e)
        {
            string db_name = db_selet.SelectedValue.ToString();
            string table_name = table_list.SelectedValue.ToString();
            
            //MessageBox.Show(table_name);
            //string sql = "desc "+table_name;
            string sql = "select column_name as Field, column_comment as asName ,column_type as type from information_schema.columns \n" +
                            "where table_schema ='" + db_name + "'  and table_name = '" + table_name + "'";
            DataSet ds = db.ExecuteQuery(sql);
           
            //DataColumn dc = new DataColumn("asName",typeof(string));
            //ds.Tables[0].Columns.Add(dc);
            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++) {
                if (string.IsNullOrWhiteSpace(ds.Tables[0].Rows[i]["asName"].ToString()))
                {
                    ds.Tables[0].Rows[i]["asName"] = ds.Tables[0].Rows[i]["Field"];
                }

            }
            
            field.DataSource = ds.Tables[0];
            foreach (DataGridViewRow gr in field.Rows) { 
              gr.Cells["Column3"].Value = true;
              gr.Cells["Column4"].Value = true;
              gr.Cells["Column5"].Value = true;
            }

            txtControl.Text = table_name.Substring(table_name.IndexOf("_") + 1);
            

        }
        //生成后台程序php,以及模板htm
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(table_list.SelectedValue.ToString()))
            {
                MessageBox.Show("必须先选表");

            }
            else { 
            
            this.setfo();
            this.gen_admin();
            }
        }

        //获取gridview 中的值并存到List<field_obj>
        public void setfo() {

            
            fo.Clear();
            
            try
            {
                foreach (DataGridViewRow dr in field.Rows)
                {
                    obj_field of = new obj_field();
                    string Field = dr.Cells["Column1"].Value.ToString();
                    string asName = null;
                    bool select = false;
                    bool search = false;
                    bool edit = false;
                    
                    if (dr.Cells["Column2"].Value != null)
                    {
                        asName = dr.Cells["Column2"].Value.ToString();
                    }
                    if (dr.Cells["Column3"].Value != null)
                    {
                        select = bool.Parse(dr.Cells["Column3"].Value.ToString());
                    }
                    if (dr.Cells["Column4"].Value != null)
                    {
                        search = bool.Parse(dr.Cells["Column4"].Value.ToString());
                    }
                    if (dr.Cells["Column5"].Value != null)
                    {
                        edit = bool.Parse(dr.Cells["Column5"].Value.ToString());
                    }

                    of.field_name = Field;
                    of.as_name = asName;
                    of.select = select;
                    of.search = search;
                    of.edit = edit;
                    of.type = dr.Cells["Column6"].Value.ToString();
                    string size =  of.type.Substring(of.type.IndexOf("(")+1);

                    of.size =  size.TrimEnd(")".ToCharArray());

                    fo.Add(of);
                }
                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }
        public void keke_debug(string str)
        {
            MessageBox.Show(str);
        }
        //生成后台的代码
        public void gen_admin() {
            //控制器名称
            string control_name = txtControl.Text.ToString();
            //内容
            string content;

            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter ="PHP files(*.php)|*.php";
            sd.FilterIndex = 2;
            sd.RestoreDirectory = true;
            //sd.FileName = control_name;
            string fn = control_name.Substring(control_name.LastIndexOf("_") + 1);
            sd.FileName = fn;
            sd.Title = "保存控制器_"+company;
            //保存php文件
            if (sd.ShowDialog() == DialogResult.OK) {
                //获得文件路径   
                string localFilePath = sd.FileName.ToString();   
                //获取文件名，不带路径   
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);   

                //获取文件路径，不带文件名   
                string FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));   
                
                System.IO.FileStream fs = (System.IO.FileStream) sd.OpenFile();
                
                content = helper.Keke_Content.getAdminPHP(fo, control_name, table_list.SelectedValue.ToString());
                //content = helper.KekeFile.utf2gbk(content);
                helper.KekeFile.write(fs, content);

            }
            SaveFileDialog sdh = new SaveFileDialog();
            sdh.Filter = "Html files(*.htm)|*.htm";
            sdh.FilterIndex = 2;
            sdh.RestoreDirectory = true;
            sdh.Title = "列表页保存_" + company;
            sdh.FileName = fn;
            if (sdh.ShowDialog() == DialogResult.OK) {
                content = null;
                content = helper.Keke_Content.getAdminHtml(fo, control_name, table_list.SelectedValue.ToString());

                System.IO.FileStream fs = (System.IO.FileStream)sdh.OpenFile();
                helper.KekeFile.write(fs, content);
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Html files(*.htm)|*.htm";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;
            sfd.Title = "编辑添加页保存_" + company;
            sfd.FileName = fn + "_add";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                content = null;
                content = helper.Keke_Content.getAdminEditHtml(fo, control_name, table_list.SelectedValue.ToString());

                System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();
                helper.KekeFile.write(fs, content);
            }


        
        }
        //生成用户中心的代码
        public void gen_user() {
            cname = txtControl.Text.ToString();
            User u = new User(fo,cname);
            u.Show();
        }
       




        private void 武汉客客ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Activate();
            ab.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0); 
        }

        private void 生成模型文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog db = new FolderBrowserDialog();
            db.SelectedPath = @"D:\KKserv\wwwroot";
            
            db.ShowNewFolderButton = true;
            db.Description = "选择模型文件保存的目录，一般在/class/model by"+company;
            db.ShowDialog();
            string dir = db.SelectedPath;
            this.txtDir.Text = dir;

        }

        private void field_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string db_name = db_selet.SelectedValue.ToString();
            string table_name = table_list.SelectedValue.ToString();

            if (field.Rows[e.RowIndex].Cells["Column2"] == field.CurrentCell)
            {
                string nvalue = field.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
                string column_name = field.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                string type = field.Rows[e.RowIndex].Cells["Column6"].Value.ToString();
                //string g  = helper.KekeFile.utf2gbk(nvalue);
                string sql = "alter table "+db_name+"."+table_name+" modify column "+column_name+" "+type+" comment'"+nvalue+"';";

                db.ExecuteNonQuery(sql);
            }
            
            
            //MessageBox.Show(nvalue);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string dir = txtDir.Text.ToString();
            string db = db_selet.Text.ToString();

            if (!string.IsNullOrWhiteSpace(dir))
            {
                helper.Keke_Model.genModel(dir,db ,dts);
                MessageBox.Show("模型文件生成完成!","生成完成" , MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else 
            {
                this.生成模型文件ToolStripMenuItem_Click( sender, e);
            }

        }

        private void 数据升级文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBupdate dbu = new DBupdate();
            dbu.ShowDialog();
        }



        
        
        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(table_list.SelectedValue.ToString()))
            {
                MessageBox.Show("必须先选表");

            }
            else
            {

                this.setfo();
                this.gen_user();
                
                
                Form1.cname = txtControl.Text.ToString();
                Form1.table = table_list.SelectedValue.ToString();
                 
            }
            
        }
       

        
    }

   public  class obj_field {

        public string field_name;
        public string as_name;
        public bool select;
        public bool search;
        public bool edit;
        public string type;
        public string size;
    }
}
