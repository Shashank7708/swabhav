using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello";
            int a = 10;
            InParamExample( in str, in a);

            ConstructorEg cEg = new ConstructorEg() { Name = "Face it" };
            cEg.Name = "Java";
            cEg.abc = "java";

            Console.Read();
        }

        static void InParamExample(in string s,in int a) // in specify the value is readonly i.e it cannot be modified
                                                         // ref param need to be initialize before passing and may be modified
                                                         // out param needs to be initialize in method ,and must be modified

        {
            string ab = s;
            ab = "rr";
            Console.WriteLine(s);

        }
    }
    internal class ConstructorEg
    {
        public string abc { get;set; }
        public string Name { get; set; }

    }
}
