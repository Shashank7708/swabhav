using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSubArrayOfOnes1493
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1, 1, 0, 1};
            var result = LongestSubarray(arr);
            Console.WriteLine(result);
            Console.ReadLine();
        }
        //Similar to 1004
        public static int LongestSubarray(int[] nums)
        {
            int i = 0, j = -1;
            int currZCount = 0;
            int currC = 0;
            int maxSum = 0;
            int currsum = 0;
            int k = 1;
            while (i < nums.Length)
            {
                if (nums[i] == 0)
                    currZCount++;
                currC++;
                i++;
                bool maxSumCalculated = false;
                while (currZCount > k)
                {
                    currC--;
                    if (!maxSumCalculated)
                    {
                        maxSumCalculated = true;
                        currsum = currC;
                    }
                    //return maxSum;
                    // j++;
                    if (nums[++j] == 0)
                    {
                        currZCount--;

                    }
                }
                currsum = Math.Max(currC, currsum);
                maxSum = Math.Max(maxSum, currsum);

            }
            return maxSum - k;

        }
    }
}
