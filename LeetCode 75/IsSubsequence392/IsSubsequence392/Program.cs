using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSubsequence392
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "ahbgdc";
            string t = "abc";
            var result = IsSubsequence(s, t);
            Console.Read();
        }
        public static bool IsSubsequence(string s, string t)
        {
            if (s.Length <= 0)
                return true;
            else if (t.Length <= 0)
                return false;

            int bigLen = t.Length;
            int smallLen = s.Length;
            int counter = 0, i = 0;
            while (i < bigLen && counter < smallLen)
            {
                if (t[i] == s[counter])
                    counter++;
                i++;
            }
            return counter == smallLen;
        }
    }
}
