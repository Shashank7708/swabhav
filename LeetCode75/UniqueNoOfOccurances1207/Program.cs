using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueNoOfOccurances1207
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result=UniqueOccurrences(1, 2, 2, 1, 1, 3);
            Console.WriteLine(result);  
            Console.Read();
        }
        public static bool UniqueOccurrences(params int[] arr)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int i in arr)
            {
                if (dict.ContainsKey(i))
                    dict[i] = dict[i] + 1;
                else
                    dict.Add(i, 1);
            }
            HashSet<int> set = new HashSet<int>();
            foreach (var i in dict.Values)
            {
                if (set.Contains(i))
                    return false;
                set.Add(i);
            }
            return true;
        }
    }
}
