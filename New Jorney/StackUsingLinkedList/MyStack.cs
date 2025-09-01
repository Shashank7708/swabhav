using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackUsingLinkedList
{
    internal class Node
    {
        public int data;
        public Node next;
        public Node(int n) 
        {
            data = n;
            next=null;
        }
    }

    internal class Stack
    {
        private Node top;
        private int count;
        public Stack()
        {
            top=null;
            count = 0;
        }
        public void Push(int n)
        {
            Node temp=new Node(n);
            temp.next = top;
            top = temp;
            count++;
        }
        public int Pop()
        {
            var returnval = top.data;
            top = top.next;
            count--;
            return returnval;   
        }
        public int Peek() => top.data;
        public int Count => count;
    }

}
