using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace php.helper
{
    class KekeFile
    {
        public static void write(System.IO.FileStream fs,string content)
        {
            if (fs != null && !string.IsNullOrWhiteSpace(content)) {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fs,Encoding.GetEncoding("GBK"));
                sw.Write(content);
                sw.Close();
                fs.Close();
            }
        }
        public static void write(string path,string content) {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path)) {
                sw.Write(content);
            }
        }
        public static string utf2gbk(string s1) {
            byte[] bf = Encoding.UTF8.GetBytes(s1);
            return Encoding.GetEncoding("GBK").GetString(bf);
              
        }

    }
}
