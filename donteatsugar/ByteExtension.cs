using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace donteatsugar
{
    public static class ByteExtension
    {
        public static string ToX2(this SampleClass my ,byte value)
        {
            return value.ToString("X2");
        }
    }
}
