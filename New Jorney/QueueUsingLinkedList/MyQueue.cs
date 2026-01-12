using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUsingLinkedList
{
    internal class Node
    {
        public int data;
        public Node next;
        public Node(int n)
        { 
            data=(int)n;
            next = null;
        }
    }
    internal class MyQueue
    {
        public Node end;
        public Node front;
        public int count;
        public MyQueue()
        {
            end = null;
            front = null;
            count = 0;
        }
        public void Push(int n)
        {

            Node temp = new Node(n);
            if (front == null)
            {
                front = end = temp;
            }
            else
            {
                end.next= temp;
                end = temp;
            }
            count++;
        }
        public int Pop()
        {
            var returnVal = front.data;
            front = front.next;
            count--;
            return returnVal;
        }
        public int Count()=> count;
    }
}
