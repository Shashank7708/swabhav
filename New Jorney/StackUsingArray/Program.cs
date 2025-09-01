using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackUsingArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack st = new MyStack(10);
            st.Push(10);
            st.Push(5);
            st.Push(4);
            st.Push(1);
            Console.WriteLine("Size " + st.Count());
            var v1=st.Pop();
            var v2=st.Pop();
            Console.WriteLine($"v1 {v1} and v2={v2} ");
            var peek=st.Peek();
            Console.WriteLine("Size " + st.Count()+"  Peek="+peek);
            Console.ReadLine();
        }
    }
}
