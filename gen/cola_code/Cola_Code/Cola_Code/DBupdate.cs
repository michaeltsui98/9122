using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace php
{
    public partial class DBupdate :Form 
    {
        static helper.MysqlUtil mydb = new helper.MysqlUtil();

        static string oldDB = null;
        static string newDB = null;
        static List<string> querys = null ;
        static int highestPercentageReached = 0;
      
        public DBupdate()
        {
            InitializeComponent();
           // Shown += new EventHandler(button1_Click);
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            
        }

        private void DBupdate_Load(object sender, EventArgs e)
        {
            
            cmbOld.DataSource = Form1.dbs;

            List<string> newdb =new List<string>();

            newdb = Form1.dbs.ToArray().ToList();
           
            cmbNew.DataSource = newdb;
            querys = new List<string>();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync();
            //progressBar1.PerformStep();
            //得到选中的新库与老库
            oldDB = cmbOld.SelectedValue.ToString();
            newDB = cmbNew.SelectedValue.ToString();
            if (oldDB == newDB) {
                MessageBox.Show("两个库不能一样");
                
            }
            querys = new List<string>();
            //backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.DoWork += updateDBworker;
           // backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            //backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            highestPercentageReached = 0;
            backgroundWorker1.RunWorkerAsync();
            btnUpdate.Enabled = false;
           
            //btnUpdate.Enabled = true;
             //updateDb(oldDB, newDB);
            
            //MessageBox.Show("数据库升级完成","操作提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void updateDBworker(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            updateDb(oldDB, newDB,worker,e);
            updateTableContent();
           
        }
        
        //更新表结构
        static void updateDb(string oldDB, string newDB, BackgroundWorker worker, DoWorkEventArgs e)
        {
            
            DataTable oldbTables = getDbTable(oldDB);

            DataTable newdbTables = getDbTable(newDB);
            int count = newdbTables.Rows.Count;

            int n = 0;

            foreach (DataRow dr in newdbTables.Rows) {
                ++n;
                string newTable = dr[0].ToString();
                List<DataRow> fdr =  findTable(oldDB,oldbTables, newTable);
                string oldTable = null;
                if (fdr.Count > 0)
                {
                    //有相同的表，更新表结构
                    oldTable =  fdr.First()["Tables_in_"+oldDB].ToString();
                    updateTableStruct(newDB, newTable, oldDB, oldTable);

                }else {
                    //创建新表
                    DataTable dts =  getTableStruct(newDB,newTable);
                    List<DataRow> ldr = getColumnByTable(dts, null, true);
                    string columnName = ldr.First()["column_name"].ToString();
                    string columnType = ldr.First()["column_type"].ToString();  //int(11)
                    string extra = ldr.First()["extra"].ToString();
                    if (newTable == "keke_witkey_config")
                    {
                        renameTable(oldDB, "keke_witkey_basic_config", newTable);
                    }
                    else
                    {
                        createNewTable(newDB, newTable, oldDB, newTable, columnName, columnType, extra);
                    }
                }

                int percentComplete =
                    (int)((float)n / (float)count * 100);
                if (percentComplete > highestPercentageReached)
                {
                    highestPercentageReached = percentComplete;
                    worker.ReportProgress(percentComplete);
                }
            }
        }
        //获取表中字段的信，可按查主键查，或者是字段名来查
        static List<DataRow> getColumnByTable(DataTable dt ,string columnName,bool isPk=false) 
        {
            StringBuilder sb = new StringBuilder();
            
            if (isPk) {
                sb.AppendLine("column_key = 'PRI'");
            }
            if (string.IsNullOrEmpty(columnName) == false) 
            {
                sb.AppendLine("and column_name = '" + columnName + "'");
            }
            
            DataRow[] dr = dt.Select(sb.ToString());
            return dr.ToList();
        
        }
        static List<DataRow> findTable(string dbName,DataTable soruceTable,string tableName) {
            DataRow[] dr  =  soruceTable.Select("Tables_in_"+dbName+"= '"+tableName+"'");
            return dr.ToList();
        }

        //更新表结构
        static void updateTableStruct(string newDb,string newTable,string oldDb,string oldTable) {
            DataTable newTableStruct = getTableStruct(newDb, newTable);
            DataTable oldTableStruct = getTableStruct(oldDb, oldTable);
            //更新旧表的主键
            foreach (DataRow ndr in newTableStruct.Rows) {
                diffColum(ndr, oldTableStruct, oldTable);
            }

        }
        static void diffColum(DataRow ndr, DataTable dt,string oldTable) { 
              string new_col_name = ndr["column_name"].ToString();
              string new_col_type = ndr["column_type"].ToString();
              string new_col_default = ndr["column_default"].ToString();
              bool new_col_isnull = ndr["is_nullable"].ToString()=="NO"?false:true;
              string extra = ndr["extra"].ToString();
              bool ispk = ndr["column_key"].ToString()=="PRI"?true:false;
              List<DataRow> dr = dt.Select("column_name = '"+new_col_name+"'").ToList();
              string old_col_name = null;
              
              if (dr.Count == 1)
              {
                  old_col_name = dr.First()["column_name"].ToString();
                  bool old_is_pk = dr.First()["column_key"].ToString() == "PRI" ? true : false;
                  if (ispk && old_is_pk == false)
                  {
                      ispk = true;
                      //先删除已经存在的PK
                      List<DataRow> pkdr = dt.Select("column_key='PRI'").ToList();
                      if (pkdr.Count>0)
                      {
                          delColumn(oldDB, oldTable, pkdr.First()["column_name"].ToString());
                      }

                  }
                  else {
                      ispk = false;
                  }
                  
                  addColumn(oldDB, oldTable, new_col_name, old_col_name, new_col_type, new_col_default, new_col_isnull, extra, ispk);
              }
              else 
              {
                  if (ispk == true) {
                      //先删除已经存在的PK
                      List<DataRow> pkdr = dt.Select("column_key='PRI'").ToList();
                      delColumn(oldDB, oldTable, pkdr.First()["column_name"].ToString());
                  }
                  addColumn(oldDB, oldTable, new_col_name, null, new_col_type, new_col_default, new_col_isnull, extra, ispk);
              }
        }

        //获取库中的表
        static DataTable getDbTable(string dbName)
        {
            string sql = string.Format("SHOW TABLES FROM {0}", dbName);
            DataSet ds = mydb.ExecuteQuery(sql);
            return ds.Tables[0];
        }
        //获取表结构
        static DataTable getTableStruct(string dbName, string tableName)
        {
            string sql = "select column_name,data_type,column_type,column_key,extra,column_default,column_comment,is_nullable from information_schema.columns " +
                         "where table_schema ='" +dbName+ "'  and table_name = '" + tableName + "'";
            DataSet ds = mydb.ExecuteQuery(sql);
            return ds.Tables[0];
        }

        //旧库没有表的就创建新表，并复制数据,带上主键
        static  void createNewTable(string sourceDB,string sourceTable , string targetDB,string targetTable,string pk ,string columnType,string extra) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("create table {0}.{1}",targetDB,targetTable));
            if (string.IsNullOrEmpty(pk)==false) {
                sb.AppendLine("( "+pk+" ");
            }
            if (string.IsNullOrEmpty(columnType) == false)
            {
                sb.AppendLine(columnType);
            }
            string ctype = columnType.Substring(0, columnType.IndexOf("("));
            if (string.IsNullOrEmpty(extra)==false)
            {
                sb.AppendLine(extra);
            }
            sb.AppendLine(" primary key)");
            sb.AppendLine(string.Format("select * from {0}.{1}",sourceDB,sourceTable));
            
            querys.Add(sb.ToString());
            mydb.ExecuteNonQuery(sb.ToString());
        }

        //添加或编辑字段
        static  void addColumn(string dbName,string tableName,string columnName,string oldColumn,string columnType,string defaultValue,bool is_null,string extra,bool isPk) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("alter table {0}.{1} ",dbName,tableName));
            if (oldColumn != null)
            {
                sb.AppendLine("change `" + oldColumn + "`");
            }
            else {
                sb.AppendLine("add");
            }
            sb.AppendLine("`"+columnName+"`");
            sb.AppendLine(columnType);
            
            if (string.IsNullOrEmpty(defaultValue)==false)
            {
                sb.AppendLine("default "+defaultValue+"");
            }

            if (is_null == true)
            {
                sb.AppendLine("null");
            }
            else {
                sb.AppendLine("not null");
            }
            if (string.IsNullOrEmpty(extra) == false) {
                sb.AppendLine("auto_increment");
            }
            if (isPk == true) {
                sb.AppendLine(",add primary key ("+columnName+"); ");
            }
            querys.Add(sb.ToString());
            mydb.ExecuteNonQuery(sb.ToString());

        }

        //删除字段
        static void delColumn(string dbName, string tableName, string columnName)
        {
            string sql = string.Format("alter table {0}.{1} drop column {2};",dbName,tableName,columnName);
            querys.Add(sql);
            mydb.ExecuteNonQuery(sql);
        }
        //修改字段
        static void modfiyColumn(string dbName, string tableName, string columnName, string columnType, int len, string defaultValue, bool is_null)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("alter table {0}.{0} ", dbName, tableName));
            sb.AppendLine("modify");
            sb.AppendLine(columnName);
            sb.AppendLine(columnType);
            if (len > 0)
            {
                sb.AppendLine(string.Format("({0})", len));
            }
            if (string.IsNullOrEmpty(defaultValue) == false)
            {
                sb.AppendLine("default " + defaultValue + "");
            }

            if (is_null == true)
            {
                sb.AppendLine("null");
            }
            else
            {
                sb.AppendLine("not null");
            }
            mydb.ExecuteNonQuery(sb.ToString());
        }
        static void renameTable(string dbName, string tableName,string newTable) {
            string sql = string.Format("alter table {0}.{1} rename to {0}.{2}",dbName,tableName,newTable);
            querys.Add(sql);
            mydb.ExecuteNonQuery(sql);
        }
        //添加索引
        static void addIndex(string dbName, string tableName, string columnName)
        {
            string sql = string.Format("alter table {0}.{1} ADD INDEX ({2});", dbName, tableName, columnName);
            querys.Add(sql);
            mydb.ExecuteNonQuery(sql);
        }
        //删除索引
        static void delIndex(string dbName, string tableName, string columnName)
        {
            string sql = string.Format("alter table {0}.{1} drop column {2};", dbName, tableName, columnName);
            mydb.ExecuteNonQuery(sql);
        }

        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
           
        }
        
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

           
            progressBar1.Style = ProgressBarStyle.Continuous;

            progressBar1.Value = e.ProgressPercentage;

            this.Text = e.ProgressPercentage + "%";
            lblProc.Text = this.Text;
           
        }

       static void updateTableContent(){
            //memer表
           string sql = "update "+oldDB+".keke_witkey_member a LEFT JOIN "+oldDB+".keke_witkey_space b \n" +
                        "on a.uid = b.uid \n" +
                        "set a.salt = a.rand_code ,a.sec_code = b.sec_code,\n" +
                        "b.group_id = case b.user_type WHEN 1 then 3 WHEN 2 then 2 end ";
           querys.Add(sql);
           mydb.ExecuteNonQuery(sql);
           //用户认证的数据


       }

       private void button1_Click_1(object sender, EventArgs e)
       {
           if (querys.Count > 0)
           {
               StringBuilder sb = new StringBuilder();
               //foreach (string query in querys)
               //{
                   //sb.AppendLine(query);
               //}


               SaveFileDialog sfd = new SaveFileDialog();
               sfd.Filter = "php files(*.php)|*.php";
               sfd.FilterIndex = 2;
               sfd.RestoreDirectory = true;
               sfd.Title = "数据库升级文件";
               sfd.FileName = "update_sql";
               if (sfd.ShowDialog() == DialogResult.OK)
               {
                   string content = null;
                   content = helper.DbUpdateContentToPhp.getPhpContent(querys,newDB,oldDB);

                   System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();
                   helper.KekeFile.write(fs, content);
               }
               
           }
           else {
               querys.Add("test");
           }

       }



       private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
       {
           MessageBox.Show("数据库升级完成", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
           btnUpdate.Enabled = true;
       }
        
    }
}
