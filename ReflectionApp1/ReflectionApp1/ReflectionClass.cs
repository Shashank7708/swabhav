using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionApp1
{
    class ReflectionClass
    {
        int q;
        int a = 10;
        public int randomno = 20;
        public int GetAndSetValue
        {
            set { q = value; }
            get { return q; }
        }
        public int method1(int a,int b)
        {
            return 20;
        }

        public void method2()
        {
            Console.WriteLine("Hello World");
        }
    }
}
