using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace php.helper
{
    class DbUpdateContentToPhp
    {

        static string php_start = "<?php define (\"IN_KEKE\", TRUE );\r\n ";
        static string php_mem = "/** \r\n * @copyright keke-tech \r\n * @author Michaeltsui98 \r\n * @version 3.0 {0} \r\n */\r\n";
        
       public  static string getPhpContent(List<string> querys,string newDb,string oldDb) {
            php_mem = string.Format(php_mem, DateTime.Now);
            StringBuilder sb = new StringBuilder();
            sb.Append(php_start);
            sb.Append(php_mem);
            sb.AppendLine("$db30 = \""+newDb+"\";");
            //sb.AppendLine("$db21 = \""+oldDb+"\"; );");
            sb.AppendLine("error_reporting ( 0 );");
            sb.AppendLine("$i_model = 1;");
            sb.AppendLine("require_once 'app_comm.php';");
            foreach (string sql in querys) {
                sb.AppendLine("$querys[] = \""+sql+"\";");
            }
            sb.AppendLine("foreach ($querys as $v){");
            sb.AppendLine("\t\t$v = strtr($v,array(\"keke_\"=>TABLEPRE,\""+oldDb+".\"=>DBNAME.'.',\""+newDb+".\"=>$db30.'.'));");
            sb.AppendLine("\t\tdb_factory::execute($v);");
            sb.AppendLine("}");
            sb.AppendLine(" echo '升级成功！';");
           
            return sb.ToString();
        
        }

    }
}
