using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringComparison443
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string arr = "a";
            var result = Compress(arr.ToCharArray());
            Console.Write(result);
            Console.Read();

        }

        public static int Compress(char[] chars)
        {
            int charCount = 0; int uniqueCount = 0;
            if (chars.Length == 1)
                return charCount + 1;

            for (int i = 0; i < chars.Length; i++)
            {
                char ch = chars[i];
                charCount = 1;
                while (chars.Length > i + 1 && chars[i + 1] == ch)
                {
                    charCount++;
                    i++;
                }
                chars[uniqueCount++] = ch;
                if (charCount > 1)
                {
                    foreach (var c in charCount.ToString())
                        chars[uniqueCount++] = c;
                }
            }
            Array.Resize(ref chars, uniqueCount);
            return uniqueCount;
        }
    }
}
