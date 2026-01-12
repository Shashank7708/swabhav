using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOnlyConst
{
    class Program
    {
        const int a = 10;
        readonly static int b=76;
        readonly int q = 20;

        static void Main(String[] args)
        {
            Program p = new Program();
            b = 45;
            Console.WriteLine("I have written as=  " + a + "    " + b+"     "+q);
            Console.ReadLine();
        }

        Program()
        {
            q= 7658577;
            Console.WriteLine("I am in constructor");
            
        }

    }
}