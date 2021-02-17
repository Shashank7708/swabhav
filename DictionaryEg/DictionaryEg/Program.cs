using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DictionaryEg
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,object> ht = new Dictionary<string, object>();
            Console.WriteLine("DIctionary Eg:");
            Console.WriteLine("Employee Details:");
            ht.Add("Eid", 1010);
            ht.Add("Ename", "Chinmay");
            ht.Add("Job", "Asst Manager");
            ht.Add("Email", "chinmay@gmail.com");
            Console.WriteLine("\nPrinting Keys:");
            foreach (string key in ht.Keys)
            {
                Console.WriteLine(key+":"+ht[key]);
            }
           
            Console.ReadLine();
        }
    }
}
