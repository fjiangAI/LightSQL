using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSQL.IO
{
    /// <summary>
    /// 这是一个文件读写的类，最好可以配合win32里的打开保存对话框使用。
    /// </summary>
    public class FileHelper
    {
        //文件的URL
        string url = "";
        public FileHelper(string url)
        {
            this.url = url;
        }
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="str">要写的数据</param>
        /// <param name="code">编码格式，有UTF-8/Unicode/ASCII可选</param>
        /// <returns></returns>
        public bool write(string str,string code)
        { byte[] buf=null;
            FileStream xiaFile = new FileStream(@url, FileMode.Create);
            if(code=="utf-8"|| code == "UTF-8")
            {
                buf= Encoding.UTF8.GetBytes(str);
            }
            else if (code == "unicode" || code == "Unicode")
            {
                buf = Encoding.Unicode.GetBytes(str);
            }
            else if(code=="ASCII")
            {
                buf = Encoding.ASCII.GetBytes(str);
            }
            else
            {
                buf = Encoding.Default.GetBytes(str);
            }
            xiaFile.Write(buf, 0, buf.Length);
            xiaFile.Flush();
            xiaFile.Close();
            return true;
        }
        /// <summary>
        /// 采用系统默认的编码方式进行写文件。
        /// </summary>
        /// <param name="str">要写的数据</param>
        /// <returns>如果成功返回true</returns>
        public bool write(string str)
        {
            byte[] buf = null;
            FileStream xiaFile = new FileStream(@url, FileMode.Create);
            buf = Encoding.Default.GetBytes(str);
            xiaFile.Write(buf, 0, buf.Length);
            xiaFile.Flush();
            xiaFile.Close();
            return true;
        }

        /// <summary>
        /// 读文件（默认使用系统自带编码格式）
        /// </summary>
        /// <param name="str">读文件内容保存到str</param>
        /// <returns>读文件成功返回true</returns>
        public string read()
        {
            string str;
            FileInfo fi = new FileInfo(@url);
            long len = fi.Length;
            FileStream fs = new FileStream(@url, FileMode.Open);
            byte[] buffer = new byte[len];
            fs.Read(buffer, 0, (int)len);
            fs.Close();
            str = Encoding.Default.GetString(buffer);
            return str;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code">编码格式，有UTF-8/Unicode/ASCII可选</param>
        /// <returns></returns>
        public string read(string code)
        {
            string str;
            FileInfo fi = new FileInfo(@url);
            long len = fi.Length;
            FileStream fs = new FileStream(@url, FileMode.Open);
            byte[] buffer = new byte[len];
            fs.Read(buffer, 0, (int)len);
            fs.Close();
            if (code == "utf-8" || code == "UTF-8")
            {
                str = Encoding.UTF8.GetString(buffer);
            }
            else if (code == "unicode" || code == "Unicode")
            {
                str = Encoding.Unicode.GetString(buffer);
            }
            else if (code == "ASCII")
            {
                str = Encoding.ASCII.GetString(buffer);
            }
            else
            {
                str = Encoding.Default.GetString(buffer);
            }
            return str;
        }
    }

}
