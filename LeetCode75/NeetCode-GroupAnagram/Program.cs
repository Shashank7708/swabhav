using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCode_GroupAnagram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = new string[]{"act", "pots", "tops", "cat", "stop", "hat"};
            var result = GroupAnagrams(s);
            Console.ReadLine();
        }
        public static List<List<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                string str = strs[i];
                int[] arr = new int[26];
                for (int j = 0; j < str.Length; j++)
                {
                    int n = str[j] - 'a';
                    arr[n]++;
                }
                string s = string.Join(",", arr);
                if (dict.ContainsKey(s))
                {
                    dict[s].Add(str);
                }
                else
                {
                    dict[s] = new List<string>();
                    dict[s].Add(str);
                }
            }
            return dict.Values.ToList<List<String>>();
        }
    }
}
