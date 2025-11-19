using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroidCollision735
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "abc";
            s = s + "r";
            int[] arr = { -2, -1, 1, 2 };
            var result = AsteroidCollision(arr);
            Console.Read();
        }

        public static int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> st = new Stack<int>();
            foreach (int ast in asteroids)
            {
                if (ast > 0)
                {
                    st.Push(ast);
                }
                else
                {
                    while (st.Count > 0 && st.Peek() > 0 && st.Peek() < Math.Abs(ast))
                    {
                        st.Pop();
                    }
                    if (st.Count == 0 || st.Peek() < 0)
                    {
                        st.Push(ast);
                    }
                    else if (st.Peek() == Math.Abs(ast))
                        st.Pop();
                }
            }
            int[] result = new int[st.Count];
            int counter = 0;
            while (st.Count != 0)
            {
                result[counter] = st.Pop();
            }
            return result;

        }
    }
}
