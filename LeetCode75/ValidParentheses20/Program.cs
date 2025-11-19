using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidParentheses20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "()[{}]";
            var r = IsValidApp1(s);
            Console.ReadLine();
        }

        public static bool IsValidApp1(string s)
        {
            while (s.Contains("{}") || s.Contains("[]") || s.Contains("()"))
            {
                s=s.Replace("{}", "").Replace("[]", "").Replace("()", "");
            }
            return s.Length == 0;
        }

        public bool IsValidApp2(string s)  //faster
        {
            Stack<char> opening = new Stack<char>();
            if (s.Length % 2 != 0 || !(s.Contains('[') || s.Contains(')') || s.Contains('}')))
                return false;
            for (int i = 0; i < s.Length; i++)
            {
                var ch = s[i];
                if (ch == '{' || ch == '[' || ch == '(')
                    opening.Push(ch);
                else
                {
                    if (opening.Count == 0)
                        return false;

                    if (ch == '}' && opening.Pop() != '{')
                        return false;
                    if (ch == ']' && opening.Pop() != '[')
                        return false;
                    if (ch == ')' && opening.Pop() != '(')
                        return false;
                }

            }
            return opening.Count == 0;
        }

    }
}
