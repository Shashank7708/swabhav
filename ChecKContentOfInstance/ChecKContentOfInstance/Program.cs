using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChecKContentOfInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            String str1 = "Hello";
            String str2 = "Hello";
            Inherit n1 = new Inherit();
            n1.Getname("romy");
            Inherit n2 = new Inherit();
            n2.Getname("romy");
           
            Console.Write("n1=n2 ?");
            Console.WriteLine(n2.Equals(n1));
            
            Console.Read();
        }

        
    }
}
