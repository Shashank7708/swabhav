using System.Numerics;
using System.Xml.Linq;

namespace LinkedList_LeetCode2
{
    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
  }
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList myList1 = new LinkedList();

            
            
            myList1.AddFirst(7);
            myList1.AddFirst(5);myList1.AddFirst(3);
            myList1.AddFirst(8);

            myList1.AddFirst(6);

            myList1.AddFirst(5);

            myList1.AddFirst(6);

            myList1.AddFirst(8);

            myList1.AddFirst(0);
            LinkedList myList2 = new LinkedList();

            myList2.AddFirst(7);
            myList2.AddFirst(9);
            myList2.AddFirst(8);
            myList2.AddFirst(5);
            myList2.AddFirst(8);
            myList2.AddFirst(0);
            myList2.AddFirst(8);
            myList2.AddFirst(7);
            myList2.AddFirst(6);
            var abc = AddTwoNumbers(myList1.head, myList2.head);
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var value1 = ReverseNo(GetNofromListNode(l1));
            var value2 = ReverseNo(GetNofromListNode(l2));
            BigInteger result = BigInteger.Parse(value1) + BigInteger.Parse(value2);
            string r1 = result.ToString();
            ListNode head = null;
            for (int i = r1.Length-1; i>=0; i--)
            {
                int val = int.Parse(r1[i].ToString());
                ListNode n = new ListNode(val);
                n.next = head;
                head = n;

            }
            return head;
        }

        static string GetNofromListNode(ListNode l1)
        {
            string temp = "";
            ListNode runner = l1;
            while (runner != null)
            {
                temp = temp + runner.val.ToString();
                runner = runner.next;
            }
            return temp;
        }
        static string ReverseNo(string x)
        {
           // BigInteger reversenum = 0;
            //BigInteger temp = x;
            /*while (temp != 0)
            {
                BigInteger val = temp % 10;
                reversenum = reversenum * 10 + val;
                temp = temp / 10;
            }
            */
            char[] arr = x.ToString().ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
    public class LinkedList
    {
        public ListNode head;

        public void printAllNodes()
        {
            ListNode current = head;
            while (current != null)
            {
                Console.WriteLine(current.val);
                current = current.next;
            }
        }

        public void AddFirst(int data)
        {
            ListNode toAdd = new ListNode();

            toAdd.val = data;
            toAdd.next = head;

            head = toAdd;
        }
/*
        public void AddLast(Object data)
        {
            if (head == null)
            {
                head = new Node();

                head.data = data;
                head.next = null;
            }
            else
            {
                Node toAdd = new Node();
                toAdd.data = data;

                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = toAdd;
            }
        }
*/
    }
}
