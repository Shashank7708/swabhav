using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxVowelinSubString1456
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "abciiidef";
            int k = 4;
            var result = MaxVowels(s, k);
            Console.WriteLine(result);//3
            Console.Read();

        }
        public static int MaxVowels(string s, int k)
        {
            int noOfVowel = 0;
            int curr = 0;
            int max = 0;
            for (int i = 0; i < k; i++)
            {
                if (IsVowel(s[i]))
                    curr++;
            }
            max = curr;
            for (int i = k; i < s.Length; i++)
            {
                char beforStartChar=s[i-k];
                char endChar=s[i];
                if (IsVowel(beforStartChar))
                    curr--;
                if (IsVowel(endChar))
                    curr++;
                if (curr > max)
                    max = curr;
            }
            return max;
        }

        public static bool IsVowel(char c)
        {
            return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
        }
    }
}
