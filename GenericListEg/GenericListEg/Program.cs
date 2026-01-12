using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace GenericListEg
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> li = new List<int>();
            Console.WriteLine("Generic List");
            Console.WriteLine("Initial Capacity :" + li.Count);
            li.Add(10);
            li.Add(30);
            li.Add(1);
            li.Add(5);
            Console.WriteLine("\nElement in List:");
            foreach(int i in li)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine("\nSorting list:");
            li.Sort();
            foreach (int i in li)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine("\nInserting an elemnt in list:");
            li.Insert(2, 90);
            foreach (int i in li)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine("\nRemoving an element in list:");
            li.RemoveAt(4);
            foreach (int i in li)
            {
                Console.Write(i + "\t");
            }
            Console.ReadLine();
        }
    }
}
