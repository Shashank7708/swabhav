using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPattern290
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program p =new Program();
             var r1=p.WordPattern("aaaa", " dog dog dog dog");  //false
            var r2=p.WordPattern("abba", "dog cat cat dog");   //true
            Console.WriteLine($"r1={r1}\t r2={r2}");
            Console.ReadLine();
        }

        public bool WordPattern(string pattern, string s)
        {
            var dict = new Dictionary<char, string>();
            var spl = s.Split(' ');
            if (spl.Length != pattern.Length)
                return false;

            for (int i = 0; i < pattern.Length; i++)
            {
                if (dict.ContainsKey(pattern[i]))
                {
                    if (dict[pattern[i]] != spl[i])
                        return false;
                }
                else
                {
                    if (dict.ContainsValue(spl[i]))
                        return false;
                    dict.Add(pattern[i], spl[i]);
                }

            }
            return true;
        }

    }
}
