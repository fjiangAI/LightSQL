using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace LightSQL.JSONConverter
{
    /// <summary>
    /// 只有序列化和反序列化操作的JSON类
    /// </summary>
   public static class JSONConverter
    {
        /// <summary>
        /// 这是序列化一个List
        /// </summary>
        /// <typeparam name="T">这是实体类</typeparam>
        /// <param name="old">这是实体列表</param>
        /// <returns>返回的是JSON格式字符串</returns>
        public static string GetJsonString<T>(List<T> old)
        {
            return new JavaScriptSerializer().Serialize(old);
        }
        /// <summary>
        /// 这是反序列化，也就是JSON传递给List的
        /// </summary>
        /// <typeparam name="T">要变成的实体类型</typeparam>
        /// <param name="JsonStr">原Json格式字符串</param>
        /// <returns>List列表</returns>
        public static List<T> JSONStringToList<T>(string JsonStr)
        {
            List<T> objs =new JavaScriptSerializer().Deserialize<List<T>>(JsonStr);
            return objs;
        }
    }
}
