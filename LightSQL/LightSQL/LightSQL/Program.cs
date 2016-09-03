using LightSQL.Entity;
using LightSQL.IO;
using LightSQL.Converter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSQL
{
    class Program
    {
        /// <summary>
        /// 主要是一些使用的方式的例子
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //内存数据库
            DataSet ds = new DataSet();
            //进行数据查询并放入内存数据库中
            {
                    string sql = "";
                    string server = ".";
                    string user = "";
                    string pwd = "";
                    string database = "";
                    SqlHelper sh = new SqlHelper(server,user,pwd,database);
                    sh.Open();
                    SqlDataAdapter sda = sh.Select_adapter(sql);
                    sda.Fill(ds, "Table1");
                    sh.Close();
            }
            //进行TabletoList映射
            {
                DataTable dt = ds.Tables["Table1"];
                List<ExampleEntity> lee = DataConvert<ExampleEntity>.ToList(dt);
            }
            //把结果写入文件中
            {
                //文件路径
                string url = "";
                string result = "";
                FileHelper fh = new FileHelper(url);
                fh.write(result,"UTF-8");
            }
           
        }
    }
}
