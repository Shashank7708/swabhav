using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowException
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I am in main");
            m1();
            Console.ReadLine();
        }
        static void m1()
        {
            Console.WriteLine("i am in m1");
            Main(null);
            m2();
        }
        static void m2()
        {
            Console.WriteLine("I am in m2");
        }
    }
}
