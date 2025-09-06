using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MinStack
{
    internal class MyStack
    {
        Stack<(int, int, int)> st;
        int small, large;
        public MyStack()
        {
            st = new Stack<(int, int, int)>();
        }

        public void Push(int n)
        {
            if (st.Count == 0)
            {
                large = n;
                small = n;
                st.Push((n, small, large));
            }
            else
            {
                large = (n > large) ? n : large;
                small=(n<small)? n : small;
                st.Push((n,small,large));
            }
        }
        public (int,int,int) Pop()
        {
            if (st.Count == 0)
                throw new Exception("Stack is empty");
            return st.Pop();
        }

        public int MinValTillCurrentTop()
        {
            return st.Peek().Item2;
        }
        public int MaxValTillCurrentTop()
        {
            return st.Peek().Item3;
        }
        public int Count { get { return st.Count; } }
    }
}
