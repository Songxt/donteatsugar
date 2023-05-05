using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace donteatsugar
{
    public class SampleClass
    {
        //私有变量
        private string _name;
        private string _name3;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //自动声明 常用
        public string Name2 { get; set; } = "ABC";

        //访问限制 只写
        public string Name3
        {
            set => _name3 = value;
        }

        //只读
        public byte Name4 { get; } = 0xF4;

        //可访问性 
        public string Name5
        {
            private get { return _name3; }
            set
            {
                _name3 = "1";
                value += "TTT";
            }
        }

        //索引器
        private byte[] arr = new byte[100];
        public byte this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }
    }
}
