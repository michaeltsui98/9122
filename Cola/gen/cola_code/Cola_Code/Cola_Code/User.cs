using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace php
{
    public partial class User : Form
    {
        public List<obj_field> of = new List<obj_field>();

        public User(List<obj_field> iof,string cname)
        {
            InitializeComponent();
            of = iof;
            txtOneMenu.Text = cname.Substring(0, cname.IndexOf("_"));
            txtTwoMenu.Text = cname.Substring(cname.IndexOf("_") + 1);
           
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            helper.User_Content.one_menu = txtOneMenu.Text.ToString();
            helper.User_Content.two_menu = txtTwoMenu.Text.ToString();
            helper.User_Content.order_field = txtDefaultOrder.Text.ToString();
            helper.User_Content.sql = txtSql.Text.ToString();
            helper.User_Content.where = txtSqlWhere.Text.ToString();
            helper.User_Content.group_by = txtSqlGroup.Text.ToString();
            bool is_list = (bool)ckbList.Checked;
            bool is_add =  (bool)ckbAdd.Checked;


            //控制器名称
            string control_name = Form1.cname;
            //内容
            string content= null;
            string fn = control_name.Substring(control_name.LastIndexOf("_") + 1);
            if (is_list)
            {
                SaveFileDialog sd = new SaveFileDialog();
                sd.Filter = "PHP files(*.php)|*.php";
                sd.FilterIndex = 2;
                sd.RestoreDirectory = true;
                //sd.FileName = control_name;
                
                sd.FileName = fn;
                sd.Title = "保存控制器";
                //保存php文件
                if (sd.ShowDialog() == DialogResult.OK)
                {

                    System.IO.FileStream fs = (System.IO.FileStream)sd.OpenFile();

                    content = helper.User_Content.getUserPHP(of, Form1.cname, Form1.table);

                    helper.KekeFile.write(fs, content);

                }
                SaveFileDialog sdh = new SaveFileDialog();
                sdh.Filter = "Html files(*.htm)|*.htm";
                sdh.FilterIndex = 2;
                sdh.RestoreDirectory = true;
                sdh.Title = "列表页保存";
                sdh.FileName = fn;
                if (sdh.ShowDialog() == DialogResult.OK)
                {
                    content = null;
                    content = helper.User_Content.getUserHtml(of, Form1.cname, Form1.table);

                    System.IO.FileStream fs = (System.IO.FileStream)sdh.OpenFile();
                    helper.KekeFile.write(fs, content);
                }

            }
            if (is_add) {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Html files(*.htm)|*.htm";
                sfd.FilterIndex = 2;
                sfd.RestoreDirectory = true;
                sfd.Title = "编辑添加页保存";
                sfd.FileName = fn + "_add";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    content = null;
                    content = helper.User_Content.getUserEditHtml(of, Form1.cname, Form1.table);

                    System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();
                    helper.KekeFile.write(fs, content);
                }
            }

            
        }

        
    }
}
