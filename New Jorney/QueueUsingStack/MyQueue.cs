using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUsingStack
{
    internal class MyQueue
    {
        private Stack<int> s1 = new Stack<int>();
        private Stack<int> s2= new Stack<int>();
        public void Enqueue(int n)
        {
            s1.Push(n);
        }
        public int Dequeue()
        {
            if (s1.Count == 0 && s2.Count == 0)
                throw new Exception("Stack is Empty");

            if (s2.Count == 0) {
                while (s1.Count > 0)
                {
                    s2.Push(s1.Pop());
                }
                
            }
            return s2.Pop();
        }
        public int Peek()
        {
            if (s1.Count == 0 && s2.Count == 0)
                throw new Exception("Stack is Empty");

            if (s2.Count == 0)
            {
                while (s1.Count > 0)
                {
                    s2.Push(s1.Pop());
                }

            }
            return s2.Peek();
        }
        public int Count { 
            get { return (s1.Count + s2.Count); } 
        } 
        
    }
}
