using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGreatestElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 12, 5, 3, 1, 2, 5, 3, 1, 2, 4, 6 };
            var result = NGE(arr);
            foreach (int i in result)
            {
                Console.Write(i+"  ");
            }
            Console.ReadLine();
        }
        public static int[] NGE(int[] arr)
        {
            int[] result=new int[arr.Length];
            Stack<int> st = new Stack<int>();
            for(int i = arr.Length - 1; i >= 0; i--)
            {
                if (i == arr.Length - 1)
                {
                    st.Push(arr[i]);
                    result[i] = -1;
                }
                else
                {
                    while (st.Count != 0 && st.Peek() <= arr[i])
                        st.Pop();

                    if (st.Count == 0)
                        result[i] = -1;
                    else
                        result[i] = st.Peek();
                    st.Push(arr[i]);    
                }
            }
            return result;
        }
    }
}
