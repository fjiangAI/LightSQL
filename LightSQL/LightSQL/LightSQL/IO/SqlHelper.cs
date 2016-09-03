using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LightSQL.IO
{
    /// <summary>
    /// 这是一个SQL帮助类
    /// </summary>
   public class SqlHelper
    {
        string order = "";
        public SqlConnection context;
        /// <summary>
        /// 这是构造函数
        /// </summary>
        /// <param name="server">服务器地址</param>
        /// <param name="user">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="database">数据库名</param>
        public SqlHelper(string server,string user,string pwd,string database)
        {
            order = String.Format("server={0};user={1};pwd={2};database={3}", server, user, pwd, database);
        }
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void Open()
        {
            string constr = order;
            context = new SqlConnection(constr);
            try
            {
                context.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        //
        /// <summary>
        /// 使用update、insert、delete语句
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <returns>返回执行行数</returns>
        public int Deal(string sql)
        {
            SqlCommand comtext1 = new SqlCommand(sql, context);
            int i = comtext1.ExecuteNonQuery();
            return i;
        }
        /// <summary>
        /// 使用Select语句返回的是SqlDataReader容器
        /// 主要是一行一行读写，数据量比较大的时候，或者只需要一条一条读的时候。
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <returns>返回sqlDataReader容器</returns>
        public SqlDataReader Select_reader(string sql)
        {
            SqlCommand comtext2 = new SqlCommand(sql, context);
            SqlDataReader dr = comtext2.ExecuteReader();
            return dr;
        }
        /// <summary>
        /// 使用Select语句返回sqlDataAdapter容器
        /// 主要适合一读读出全部表格，更新什么的可以直接同步过去。
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <returns>返回sqlDataAdapter容器</returns>
        public SqlDataAdapter Select_adapter(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, context);
            return da;
        }
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            try
            {
                context.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

    }

}
