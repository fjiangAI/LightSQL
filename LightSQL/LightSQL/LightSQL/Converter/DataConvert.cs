using LightSQL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSQL.Converter
{   /// <summary>
    /// 这就是数据转换类
    /// </summary>
    /// <typeparam name="T">这是要转换的类型</typeparam>
    public static class DataConvert<T> where T : DataEntityBase, new()
    {
        /// <summary>
        /// 这就是把一行转换为一个实体的方法。
        /// </summary>
        /// <param name="dr">一行</param>
        /// <returns>返回的是一个T泛型</returns>
        public static T ToEntity(DataRow dr)
        {
            T entity = new T();
            Type info = typeof(T);
            var members = info.GetMembers();
            foreach (var mi in members)
            {
                if (mi.MemberType == System.Reflection.MemberTypes.Property)
                {
                    //读取属性上的datafield特性
                    object[] attributes = mi.GetCustomAttributes(typeof(DataFieldAttribute), true);
                    foreach (var attr in attributes)
                    {
                        var dataFieldAttr = attr as DataFieldAttribute;
                        if (dataFieldAttr != null)
                        {
                            var propInfo = info.GetProperty(mi.Name);
                            if (dr.Table.Columns.Contains(dataFieldAttr.ColumnName))
                            {
                                //根据columnName,将dr中的相对字段赋值给Entity属性
                                propInfo.SetValue(entity, Convert.ChangeType(dr[dataFieldAttr.ColumnName], propInfo.PropertyType), null);
                            }
                        }
                    }
                }
            }
            return entity;
        }
        /// <summary>
        /// 这就是把列表DataTable转换成List的方法
        /// </summary>
        /// <param name="dt">要变成持久层的Datatable类型数据</param>
        /// <returns>返回的是符合T的泛型列表</returns>
        public static List<T> ToList(DataTable dt)
        {
            List<T> list = new List<T>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ToEntity(dr));
            }
            return list;
        }
    }

}
