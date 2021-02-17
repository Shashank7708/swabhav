using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFaceEg1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass1 m1 = new MyClass1();
            
            
            Interface1 i1 = new MyClass1();
            i1.method2();
            Console.ReadLine();
        }
    }

    
}
