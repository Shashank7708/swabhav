using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "abctr";
            string str2 = "pqr";
            var result = MergeString(str1, str2);
            Console.WriteLine(result);

           
            int[] nums1 = { 1, 2, 3 };
            int[] nums2 = { 2, 4, 6 };
            var res2 = FindDifference(nums1,nums2);
            Console.WriteLine(res2);
            for(int i = 0; i < res2.Count; i++) { 
            
                foreach(int j in res2[i])
                Console.Write(j + "\t");
            }

            var res3 = FindDifference1(nums1, nums2);
            Console.WriteLine(res3);
            for (int i = 0; i < res3.Count; i++)
            {

                foreach (int j in res3[i])
                    Console.Write(j + "\t");
            }
            Console.Read();
        }

        public static string MergeString(string str1, string str2)
        {
            if (str1.Length <= 0 ||str2.Length<=0)
                return str1+str2;
            StringBuilder sb=new StringBuilder();
            int counter = 0;
            while (counter < str1.Length && counter < str2.Length)
            {
                sb.Append(str1[counter]).Append(str2[counter]); 
                counter++;
            }
            if(counter<str1.Length)
                sb.Append(str1.Substring(counter,str1.Length-counter));
            else 
                sb.Append(str2.Substring(counter, str2.Length - counter));
            return sb.ToString();

        }
        public static IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
                HashSet<int> hash1 = new HashSet<int>();
                HashSet<int> hash2 = new HashSet<int>();
                foreach (var i in nums1)
                {
                    hash1.Add(i);
                }
                foreach (var i in nums2)
                {
                    hash2.Add(i);
                }
                List<List<int>> returnLst = new List<List<int>>();
                HashSet<int> h1 = new HashSet<int>();
                HashSet<int> h2 = new HashSet<int>();
                foreach (int i in nums1)
                {
                    if (!hash2.Contains(i))
                        h1.Add(i);
                }
                foreach (int i in nums2)
                {
                    if (!hash1.Contains(i))
                        h2.Add(i);
                }
                returnLst.Add(h1.ToList());
                returnLst.Add(h2.ToList());
                return returnLst.Cast<IList<int>>().ToList();
        }

        public static IList<IList<int>> FindDifference1(int[] nums1, int[] nums2)
        {
            HashSet<int> hash1 = new HashSet<int>();
            HashSet<int> hash2 = new HashSet<int>();
            foreach (var i in nums1)
            {
                hash1.Add(i);
            }
            foreach (var i in nums2)
            {
                hash2.Add(i);
            }
            List<List<int>> returnLst = new List<List<int>>();

            foreach (int i in nums1)
            {
                if (hash2.Contains(i))
                    hash2.Remove(i);
            }
            foreach (int i in nums2)
            {
                if (hash1.Contains(i))
                    hash1.Remove(i);
            }
            returnLst.Add(hash1.ToList());
            returnLst.Add(hash2.ToList());
            return returnLst.Cast<IList<int>>().ToList();
        }
    }
}
