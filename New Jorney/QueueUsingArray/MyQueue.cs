using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUsingArray
{
    internal class MyQueue
    {
        int front = 0;
        int rear = -1;
        int[] arr = null;
        int count = 0;
        int capacity;
        public MyQueue(int size)
        {
            this.arr = new int[size];
            capacity = size;
        }
        public void Enqueue(int n)
        {
            if (count + 1 > arr.Length)
                throw new Exception("Index out of Range");
            rear = (rear + 1) % capacity;
            arr[rear] = n;
            count++;
        }
        public int Dequeu()
        {
            if (count == 0)
                throw new Exception("The Queue is empty");
            int returnval = arr[front++];
            count--;
            return returnval;

        }
        public int Count()
        {
            return this.count;
        }
        public int Peek()
        {
            return arr[front];
        }
    }
}
