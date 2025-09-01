using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackUsingArray
{
    internal class MyStack
    {
        int top = -1;
        int[] st = null;
        public MyStack(int size)
        {
            st = new int[size];
        }
        public void Push(int n)
        {
            if (top+1 > st.Length)
                throw new IndexOutOfRangeException("Index is out of range");
            st[++top] = n;
        }
        public int Pop()
        {
            if (top == -1)
                throw new Exception("There are no element");
            int val=st[top];
            st[top--] = 0;
            return val;
        }
        public int Count() {
            return top + 1; ;
        }
        public int Peek()
        {
            return st[top];
        }
    }
}
