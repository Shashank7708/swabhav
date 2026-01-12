using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreviousSmallerElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5,7,9,6,7,4,5,1,3,7 };
            var result = PSEUsingStack(arr);
            foreach (int i in result)
            {
                Console.Write(i + "  ");
            }
            Console.ReadLine();
        }

        public static int[] PSEUsingStack(int[] arr)
        {
            int n = arr.Length;
            int[] result = new int[arr.Length];
            Stack<int> st = new Stack<int>();
            for (int i =0; i <=n-1; i++) 
            {
                if (i == 0)
                {
                    st.Push(-1);
                }
                while (st.Count != 0 && st.Peek() >= arr[i])
                {
                    st.Pop();
                }
                    
                if (st.Count != 0)
                {
                    result[i] = st.Peek();
                    // st.Pop();
                }
                else
                    result[i] = -1;
                    
                st.Push(arr[i]);
                

            }
            return result;
        }

    }
}
