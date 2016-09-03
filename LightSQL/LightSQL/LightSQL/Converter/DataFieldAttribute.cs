using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSQL.Converter
{
    [AttributeUsage(AttributeTargets.Property)]
   public class DataFieldAttribute:Attribute
    {
        public string ColumnName { set; get; }
        public DataFieldAttribute(string columnName)
        {
            ColumnName = columnName;
        }

    }
}
