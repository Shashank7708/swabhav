using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace StackEg
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack mystack = new Stack();
            mystack.Push(1);
            mystack.Push("Rahul");
            mystack.Push('e');
            mystack.Push(4.5f);
            Console.WriteLine("Elemnt in Stack:");
            foreach (object i in mystack)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine("\nAfter 1st Pop");
            mystack.Pop();
            foreach (object i in mystack)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine("Does it contain Element\"1\": " + mystack.Contains(1));
            Console.ReadLine();
        }
    }
}
