using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace kSumPair1670
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 1, 5, 1, 1, 1, 1, 1, 2, 2, 3, 2, 2 };
            int k = 1;
            MaxOperationsApp2(arr, k);
        }

        public static int MaxOperationsApp2(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int counter = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int diff = k - nums[i];
                if (!dict.ContainsKey(diff))
                    dict.Add(nums[i], i);
                else
                {
                    counter++;
                    dict.Remove(nums[i]);
                }
            }
            return counter;

        }
        internal static int MaxOperationsApp1(int[] nums, int k)
        {
            Array.Sort(nums);
            int counter = 0;

            int i = 0, j = nums.Length - 1;
            while (i < j)
            {
                int sumVal = nums[i] + nums[j];
                if (sumVal == k)
                {
                    i++; j--;
                    counter++;
                }
                else if (sumVal < k)
                {
                    i++;
                }
                else
                    j--;
            }
            return counter;

        }
    }
}
