using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCoseeg
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "abc";
            Console.WriteLine(name.ToUpper().GetHashCode());
            Console.WriteLine(name.ToLower().GetHashCode());
            name = "xyz";
            Console.WriteLine(name.GetHashCode());
            Console.ReadLine();
            


        }
    }
}
