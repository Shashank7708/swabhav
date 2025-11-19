using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindDiff2Array22215
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = { 1, 2, 3 };
            int[] nums2 = { 2, 4, 6 };
            FindDifference(nums1, nums2);
            Console.Read();
        }

        public static List<List<int>> FindDifference(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> dict1 = new Dictionary<int, int>();
            Dictionary<int, int> dict2 = new Dictionary<int, int>();
            foreach (var i in nums1)
            {
                if (!dict1.ContainsKey(i))
                    dict1.Add(i, 1);
            }
            foreach (var i in nums2)
            {
                if (!dict2.ContainsKey(i))
                    dict2.Add(i, 1);
            }
            List<List<int>> returnLst = new List<List<int>>();
            HashSet<int> h1 = new HashSet<int>();
            HashSet<int> h2 = new HashSet<int>();
            foreach (int i in nums1)
            {
                if (!dict2.ContainsKey(i))
                    h1.Add(i);
            }
            foreach (int i in nums2)
            {
                if (!dict1.ContainsKey(i))
                    h2.Add(i);
            }
            returnLst.Add(h1.ToList());
            returnLst.Add(h2.ToList());
            return returnLst;
        }
    }
}
