using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;

namespace php.helper
{
    class Keke_Model
    {
        static string con = null;
        static string php_start = "<?php \r\n ";
        static string php_mem = "/** \r\n * @Copyright Michael \r\n * @author Michaeltsui98 \r\n * @version 3.0 {0} \r\n */\r\n";
        static string dir;
        static DataTable dts;
        static string db;
        static string pk;
        static  MysqlUtil mydb = new MysqlUtil(); 


        public static bool genModel(string dir ,string db ,DataTable dt ) {
            
            Keke_Model.dir = dir;
            Keke_Model.dts = dt;
            Keke_Model.db = db;

            getTable();
            
            return true;
        }
      
        public static void getTable()
        {
            //foreach tables ['Database']
            for (int i = 0 ; i < dts.Rows.Count; i++) {
                save(dts.Rows[i][0].ToString());    
            }
        }
        public static  void save(string tableName)
        {

            php_mem = string.Format(php_mem, DateTime.Now);
            con += (php_start + php_mem);

            //去掉前缀的表名
            string table_name = tableName.Substring(tableName.IndexOf("_") + 1);
            //首字母大写的表名
            string upTableName = "Tables_"+tableName;
            DataTable tableInfo = getTableInfo(tableName);


            //主键
            Keke_Model.pk = getPk(tableInfo);


            StringBuilder sb = new StringBuilder();


            sb.AppendLine("class " + upTableName + "  extends Tables_Model {");
            

            //construct
            sb.AppendLine("\t\tfunction  __construct(){");
            sb.AppendLine("\t\t\tparent::__construct ( '"+table_name+"' );");
            sb.AppendLine("\t\t\tself::$pk = '"+pk+"';");
            sb.AppendLine("\t\t}");
            sb.Append(getGet(tableInfo));
            sb.Append(getSet(tableInfo));


            //class end
            sb.Append("}");


            string c = con + sb.ToString();
            con = null;
            helper.KekeFile.write(Keke_Model.dir + @"\" + tableName + ".php", c);
        }
        
        
        public static string getGet(DataTable dt) {
            //string c = null;
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dt.Rows) {
                string nc = firstToUp(dr["column_name"].ToString()).ToString();
                sb.AppendLine("\t\tpublic function get"+nc+"(){");
                sb.AppendLine("\t\t\treturn self::$_data ['" + dr["column_name"] + "'];");
                sb.AppendLine("\t\t}");
            }
           // c = sb.ToString(); ;
            //sb = null;
            return sb.ToString();
        }

        public static string getSet(DataTable dt) {
             
            StringBuilder sb = new StringBuilder();
            //string pk = getPk(dt);
            foreach (DataRow dr in dt.Rows)
            {
                string nc = firstToUp(dr["column_name"].ToString()).ToString();
                sb.AppendLine("\t\tpublic function set" + nc + "($value){");
                sb.AppendLine("\t\t\treturn self::$_data ['" + dr["column_name"] + "'] = $value;");
                if (dr["column_name"].ToString() == pk)
                {
                    sb.AppendLine("\t\t\tself::$pk_val = $value;");
                }
                sb.AppendLine("\t\t\t$this;");
                sb.AppendLine("\t\t}");
            }
            return sb.ToString();
        }

        public static string firstToUp(string str) {
            string first = null;
            str = str.Trim();
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            else {
                first = str.Substring(0, 1);
            }
            return first.ToUpper()+str.Substring(1);
        }
        
        public static string getPk(DataTable dt) {
            string pk = null;

            foreach (DataRow dr in dt.Rows) {
                if (dr["column_key"].ToString() == "PRI") {
                    pk = dr["column_name"].ToString();
                    break;
                }
            }
            return pk;
        }
        
        public static DataTable  getTableInfo( string tableName) {
            string sql = "select column_name,data_type,column_type,column_key from information_schema.columns "+
                         "where table_schema ='"+Keke_Model.db+"'  and table_name = '"+tableName+"'";
            DataSet ds = mydb.ExecuteQuery(sql);

            return ds.Tables[0];
        }

    }
}
