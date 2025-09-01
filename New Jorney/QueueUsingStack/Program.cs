using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUsingStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            MyQueue q1=new MyQueue();
            q1.Enqueue(1);
            q1.Enqueue(3);
            q1.Enqueue(6);
            q1.Enqueue(8);
            Console.WriteLine($"Size= " +q1.Count);
            var v1 = q1.Dequeue();
            var v2 = q1.Dequeue();
            Console.WriteLine($"v1= {v1} and v2={v2}");
            Console.WriteLine($"Size= " + q1.Count);
            Console.ReadLine();
        }
    }
}
