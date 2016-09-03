using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LightSQL.XMLConverter
{
    /// <summary>
    /// 只有序列化和反序列化操作的XML类
    /// </summary>
    public static class XMLConverter
    {
        /// <summary>
        /// 根据对象，来序列化这个对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="entity">对象类</param>
        /// <returns></returns>
        public static string XMLSerialize<T>(T entity)
        {
            StringBuilder buffer = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StringWriter(buffer))
            {
                serializer.Serialize(writer, entity);
            }

            return buffer.ToString();

        }
        /// <summary>
        /// 这是反序列化，根据一个字符串，返回一个对象。
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="xmlString">XML字符串</param>
        /// <returns>目标对象</returns>
        public static T DeXMLSerialize<T>(string xmlString)
        {
            T cloneObject = default(T);
            StringBuilder buffer = new StringBuilder();
            buffer.Append(xmlString);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(buffer.ToString()))
            {
                Object obj = serializer.Deserialize(reader);
                cloneObject = (T)obj;
            }
            return cloneObject;
        }
    }
}
