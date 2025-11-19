using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecodeString394
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "3[a]2[bc]";
            DecodeString(s);
            Console.Read();
        }
        public static string DecodeString(string s)
        {
            StringBuilder sb = new StringBuilder();
            string st = null;
            string st2 = null;
            for (int i = 0; i < s.Length;)
            {
                st = "";
                st2 = "";
                int val = 0;
                while (i < s.Length && s[i] >= '0' && s[i] <= '9')
                {
                    st += s[i++];
                }
                if (!String.IsNullOrEmpty(st))
                    val = int.Parse(st);
                if (s[i] == '[')
                {
                    i++;
                    while (i < s.Length && s[i] != ']')
                        st2 += s[i++];

                    i++;
                }
                if (val > 0 && !String.IsNullOrEmpty(st))
                {
                    for (int j = 0; j < val; j++)
                        sb.Append(st2);
                }
                else
                {
                    sb.Append(s[i++]);
                }
            }
            return sb.ToString();
        }
    }
}
