using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ArrayListEg
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList(5);
            Console.WriteLine("ArrayList EG:");
            Console.WriteLine("Capacity: "+al.Capacity);
            al.Add(10);
            al.Add("Rahul");
            al.Add("Romy");
            al.Add('a');
            foreach(object obj in al)
            {
                Console.Write(obj+"\t");
            }
            Console.WriteLine("\nInserting an Element");
            al.Insert(2, "Fanny");
            foreach (object obj in al)
            {
                Console.Write(obj+"\t");
            }
            Console.WriteLine("\nRemoving an element at particular index:");
            al.RemoveAt(1);
            foreach (object obj in al)
            {
                Console.Write(obj+"\t");
            }
            al.Reverse();
            Console.WriteLine("\n reversing  a ArrayList");
            foreach (object obj in al)
            {
                Console.Write(obj + "\t");
            }
            Console.ReadLine();

        }
    }
}
