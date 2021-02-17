using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectonApp
{
    public class ReflectionClass
    {
        int q;
        int a = 10;
        public int randomno = 20;
        public int GetAndSetValue
        {
            set { q = value; }
            get { q; }
        }
        public int method(int a)
        {
            
        }

        private void method2()
        {
            Console.WriteLine("Hello World ");
        }
    }
}
