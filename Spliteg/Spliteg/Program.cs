using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spliteg
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "http://www.google.com?developer=#abc#@course.net";
            substring1(str);
            Split1(str);
            Console.ReadLine();

        }
        static void split1(string str)
        {
            Console.WriteLine("Split Function");
            string[] arr = str.Split(new char[] { '/', '.', '?', '=', '@', '#' });
            Console.WriteLine("case 1:");
            Console.WriteLine("Company name " + arr[3]);
            Console.WriteLine("Developer name " + arr[7]);

            Console.WriteLine("Case 2:");
            Console.WriteLine("Company name= " + arr[3]);
            Console.WriteLine("Developer name= " + arr[7]);
            Console.WriteLine("Course name= " + arr[10]);

            arr[3] = "swabhav";
            arr[7] = "Shashank";
            Console.WriteLine("Case 3:");
            Console.WriteLine("Company name= " + arr[3]);
            Console.WriteLine("Developer name= " + arr[7]);
            Console.WriteLine("Course name= " + arr[10]);

        }
        
        static void substring1(string str)
        {
            Console.WriteLine("substring function");
            Console.WriteLine("Case1\n Company name:" + str.Substring(11, 7));
            Console.WriteLine("Developer name :" + str.Substring(34, 3));
            Console.WriteLine("Case 2:");

            Console.WriteLine("Company name" + str.Substring(11, 7));
            Console.WriteLine("developer name:" + str.Substring(34, 3));
            Console.WriteLine("Course:" + str.Substring(str.Length - 4));
            Console.WriteLine("Case 3");
            string str1 = "http://www.google.com?developer='abc'@course.net";

            Console.WriteLine("Company name:" + str1.Substring(str.IndexOf("google"), 6));
            Console.WriteLine("developer name:" + str1.Substring(str.IndexOf("abc"), 3));
            Console.WriteLine("course name=" + str1.Substring(str.Length - 4));
        }
    }
}
