using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            Console.WriteLine("HashTable Eg:");
            Console.WriteLine("Employee Details:");
            ht.Add("Eid", 1010);
            ht.Add("Ename", "Romy");
            ht.Add("Job", "Manager");
            ht.Add("Email", "romy@gmail.com");
            Console.WriteLine("\nPrinting Keys:");
            foreach(object obj in ht.Keys) 
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine("\nPrinting Values");
            foreach(object obj in ht.Values)
            {
                Console.WriteLine(obj);
            }
            Console.ReadLine();

        }
    }
}
