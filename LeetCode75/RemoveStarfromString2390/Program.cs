using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveStarfromString2390
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string st = "leet**cod*e";
            var result = RemoveStars(st);
            Console.WriteLine(result);
            Console.ReadLine();

        }
        public static string RemoveStars(string s)
        {
            StringBuilder sb = new StringBuilder();
            Stack<char> st = new Stack<char>();
            foreach (char c in s)
            {
                if (c != '*')
                    st.Push(c);
                else if (st.Count > 0)
                    st.Pop();

            }
            char[] result = st.Reverse().ToArray();
            return new String(result);
        }
    }
}
