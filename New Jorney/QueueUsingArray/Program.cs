using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUsingArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyQueue q = new MyQueue(4);
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            Console.WriteLine("Count= " + q.Count());
            var v1=q.Dequeu();
            var v2 = q.Dequeu();
            Console.WriteLine($"v1 {v1} and v2={v2} ");
            var peek = q.Peek();
            Console.WriteLine("Size " + q.Count() + "  Peek=" + peek);
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            Console.ReadLine();

        }
    }
}
