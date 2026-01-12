using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HashsetEG
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> hs = new HashSet<string> { "Rahul", "Romy", "Sonam" };
            hs.Add("Rahul");
            hs.Add(null);
            for (int i= 0; ;)
            {
                Console.WriteLine("hello");
            }
            Console.WriteLine("Hashset Eg:");
            Console.WriteLine("Element in Set");

            foreach (string i in hs)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("In HashSet, no duplicated element can be added in Hashset");
            Console.ReadLine();
        }
    }
}
