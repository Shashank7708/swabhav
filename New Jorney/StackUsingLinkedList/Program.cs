using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackUsingLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack st=new Stack();
            st.Push(1);
            st.Push(3);
            st.Push(5);
            st.Push(10);
            Console.WriteLine("Peek =" + st.Peek() + "  Size="+st.Count);
            var v1=st.Pop();
            var v2=st.Pop();
            Console.WriteLine($" v1={v1} v2={v2}");
            Console.WriteLine("Size " + st.Count);
            Console.Read();

        }
    }
}
