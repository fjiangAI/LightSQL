using LightSQL.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSQL.Entity
{
    /// <summary>
    /// 这是一个实体类的例子
    /// </summary>
    public class ExampleEntity :DataEntityBase
    {
        //这是表里的名字
        [DataField("id")]
        //这是对象里的名字
        public string Id { get; set; }
    }
}
