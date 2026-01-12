using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackUsingQueue
{
    internal class MyStack
    {
        private Queue<int> _queue;
        public MyStack()
        {
           _queue= new Queue<int>();
        }
        public void Push(int n)
        {
            if(_queue.Count == 0)
                _queue.Enqueue(n);
            else
            {
                _queue.Enqueue(n);
                for(int i = 0; i < _queue.Count - 1; i++)
                {
                    var val= _queue.Dequeue();
                    _queue.Enqueue(val);
                }
            }
        }
        public int Pop()
        {
            return _queue.Dequeue();
        }
        public int Count()=> _queue.Count;

    }
}
