using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Background
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            
             if(name==null||name=="not defined")
            {
                Console.WriteLine("Not defined");
            }
            else
            {
                Console.WriteLine(name);
            }
            Console.ReadLine();
        }
    }
}
