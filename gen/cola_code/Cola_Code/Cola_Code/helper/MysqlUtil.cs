using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
using MySql.Data;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
namespace php.helper
{
   public  class MysqlUtil
    {
        MySqlConnection conn = new MySqlConnection();
        string connString = "";
        MySqlCommand comm = new MySqlCommand();
        string host, uid, pwd;
        static string connStr = null;
        //public List<string> Databases;
         //database = MySql;
        /// <summary>
        /// 打开数据库并返回
        /// </summary>
        /// <param name="host"></param>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public List<string> openConn(string host,string uid,string pwd) {
            this.host = host;
            this.uid = uid;
            this.pwd = pwd;
            string cs = "Server={0}; Uid={1};Pwd={2};Charset=utf8;";
            this.connString   = string.Format(cs,host,uid,pwd);
            conn.ConnectionString = this.connString;
            List<string> res = new List<string>();
            try
            {
                conn.Open();
                comm.Connection = conn;
                comm.CommandText = "show databases";
                
                using (MySqlDataReader dr = comm.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        res.Add(dr[0].ToString());
                    }
                }
                
            }
            catch (Exception ex) {
                throw ex;
            }
            conn.Close();
            return res;
        }
     
         
      
        public DataSet  getTable(string db_name) {
            string tmp = "Server={0}; Uid={1};Pwd={2};Charset=utf8;database={3}";
            this.connString = string.Format(tmp, this.host,this.uid,this.pwd,db_name);
            MysqlUtil.connStr = this.connString;
           return this.ExecuteQuery(string.Format("SHOW TABLES FROM {0}",db_name));            
        }

        //执行查询语句，返回dataset
        public  DataSet ExecuteQuery(string sql, MySqlParameter[] parameters)
        {
            //Debug.WriteLine(sql);
            using (MySqlConnection connection = new MySqlConnection(MysqlUtil.connStr))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                    if (parameters != null) da.SelectCommand.Parameters.AddRange(parameters);
                    da.Fill(ds, "ds");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds;
            }
        }
        public  DataSet ExecuteQuery(string sql)
        {
            return ExecuteQuery(sql, null);
        }
        //执行带参数的sql语句,返回影响的记录数（insert,update,delete)
        public  int ExecuteNonQuery(string sql, MySqlParameter[] parameters)
        {
            //Debug.WriteLine(sql);
            using (MySqlConnection connection = new MySqlConnection(MysqlUtil.connStr))
            {
                
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                try
                {
                    connection.Open();
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        //执行不带参数的sql语句，返回影响的记录数
        //不建议使用拼出来SQL
        public  int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, null);
        }

        
       


    }
}
