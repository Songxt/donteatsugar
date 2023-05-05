using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace donteatsugar
{
    public class AnonDelegate
    {
        public delegate void DoSomething(int a);
        public delegate string DoSomething2(int a, string b);
        //定义方法委托
        public void DoIt(int a)
        {
            Console.WriteLine(a);
        }

        //常用于初始化参数
        public void Config(DoSomething doMethod, int a)
        {
            doMethod(a);
        }

        // 常用于配置方法
        public string Config(DoSomething2 doMethod)
        {
            return doMethod(1,"2");
        }
    }
}
