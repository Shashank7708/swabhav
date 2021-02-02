using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverLoadingInc
{
    class Program
    {
        static void Main(string[] args)
        { int i = 9;
            
            Hi("hello");
            Hi('c');
            Hi(i);
            Hi(9.0f);
            Hi(10.0m);
            Hi(123.4);
            Hi();
            Hi(true);
            Console.ReadLine();
        }
        static void Hi(string temp)
        {
            Console.WriteLine("String="+temp);
        }
       static void Hi(char temp)
        {
            Console.WriteLine("Strtemp");
        }
        static void Hi(int temp)
        {
            Console.WriteLine(temp);
        }
        static void Hi(float temp)
        {
            Console.WriteLine(temp);
        }
        static void Hi(double temp)
        {
            Console.WriteLine(temp);
        }
        static void Hi(decimal temp)
        {
            Console.WriteLine(temp);
        }
       static void Hi()
        {
            Console.WriteLine("It prints nothing");
        }
        static void Hi(bool temp)
        {
            Console.WriteLine(temp);
        }
    }
}
