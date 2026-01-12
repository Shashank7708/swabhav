using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substringeg
{
    class Program
    {
        static void Main(string[] args)
        {
            string str ="http://www.swabhav.com?developer='abc'@course.net";
            Console.WriteLine("Case1\n Company name:" + str.Substring(11,7));
            Console.WriteLine("Developer name :" +str.Substring(34,3));
            Console.WriteLine("Case 2:");
            
            Console.WriteLine("Company name"+str.Substring(11,7));
            Console.WriteLine("developer name:" + str.Substring(34,3));
            Console.WriteLine("Course:" + str.Substring(str.Length - 4));
            Console.WriteLine("Case 3");
            string str1 ="http://www.google.com?developer='abc'@course.net";

            Console.WriteLine("Company name:"+str1.Substring(str.IndexOf("google"),6));
            Console.WriteLine("developer name:" + str1.Substring(str.IndexOf("abc"), 3));
            Console.WriteLine("course name=" + str1.Substring(str.Length - 4));

            Console.ReadLine();
        }
    }
}
