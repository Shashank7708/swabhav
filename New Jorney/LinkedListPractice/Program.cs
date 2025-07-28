namespace LinkedListPractice
{

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val=0,ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddNodeAtStart(1);
            linkedList.AddNodeAtStart(2);
            linkedList.AddNodeAtStart(3);
            linkedList.AddNodeAtEnd(4);

            ListNode current = linkedList.head;
            while (current != null)
            {
                Console.WriteLine(current.val);
                current = current.next;
            }


            Console.WriteLine("Hello, World!");
            Console.ReadLine();
        }
    }

    internal class LinkedList
    {
        public ListNode head ;
        public LinkedList()
        {
            head = null;
        }

        public void AddNodeAtStart(int data)
        {
            ListNode n1 = new ListNode(data);
            n1.next = head;
            head = n1;
        }

        public void AddNodeAtEnd(int data)
        {
            ListNode current = head;
            while (current.next != null)
                current = current.next;
            ListNode newNode = new ListNode(data);
            current.next = newNode;


        }
    }
}
