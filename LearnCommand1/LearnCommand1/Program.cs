using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCommand1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Values in command are = ");
            foreach(String i in args)
            {
                Console.Write(i+"  ");
            }
            Console.ReadLine();

        }
    }
}
