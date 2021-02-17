using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace substringTrialDuringTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "hello I am Shashank";
            str = str.Substring(0, 2) + 'a' + str.Substring(3);
            string[] arr=str.Split(new char[] {' '});
            foreach(string i in arr)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(str);
            Console.ReadLine();
        }
    }
}
