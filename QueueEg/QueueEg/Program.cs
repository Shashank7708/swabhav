using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace QueueEg
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue myQueue = new Queue();
            myQueue.Enqueue(1);
            myQueue.Enqueue("Rahul");
            myQueue.Enqueue("DIV-B");
            myQueue.Enqueue("Rollno-45");
            Console.WriteLine("Element in Queue:");
            foreach(object i in myQueue)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine("\nAfter 1 Dequeue:");
            myQueue.Dequeue();
            foreach (object i in myQueue)
            {
                Console.Write(i+"\t");
            }
            Console.WriteLine("\n--------------------------------------");
            Console.WriteLine("Does the Queue contain element\"Rahul\": " + myQueue.Contains("Rahul"));
            Console.ReadLine();
        }
    }
}
