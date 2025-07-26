using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIctionaryOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.DictionaryOperations();
            Console.ReadLine();

        }

        private void DictionaryOperations()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "Romy");
            dict.Add(2, "Sharon");
            bool isRemoved=dict.Remove(3);
            Console.WriteLine("Count= {0}", dict.Count);
            foreach(var i in dict)
            {
                Console.WriteLine($"{i.Key} : {i.Value}");
            }
            bool val = dict.ContainsKey(2);

            dict.Clear();
            
        }
    }
}
