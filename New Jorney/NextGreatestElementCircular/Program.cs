using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGreatestElementCircular
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 10, 12, 1, 11 };
            var result = NGEinCiruclarUsingStack(arr);
            foreach (int i in result)
            {
                Console.Write(i+"  ");
            }
            Console.ReadLine();
        }

        public static int[] NGEinCiruclarUsingStack(int[] arr) 
        {
            int n=arr.Length;
            int[] result=new int[arr.Length];
            Stack<int> st=new Stack<int>();
            for (int i = (2*n) - 1; i >= 0; i--) //Virtually the array is [2,10,12,1,11,2,10,12,1,11]
            {
                int index = i % n;
                if(i == (2 * n) - 1)
                {
                    st.Push(-1);
                }
                else
                {
                    while(st.Count!=0 && st.Peek() <= arr[index])
                    {
                        st.Pop();
                    }
                    if (i <=n-1)
                    {
                        if (st.Count != 0)
                        {
                            result[i] = st.Peek();
                            st.Pop();
                        }
                        else
                            result[i] = -1;
                    }
                    st.Push(arr[index]);
                }
                
            }
            return result;
        }
    }
}
