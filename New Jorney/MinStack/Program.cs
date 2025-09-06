using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack st=new MyStack();
            st.Push(10);
            st.Push(4);
            st.Push(5);
            st.Push(6);
            st.Push(3);
            var v1=st.Pop();
            Console.Write(v1.Item2);
            Console.ReadLine();


        }
    }
}
