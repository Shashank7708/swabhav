using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPivot724
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = PivotIndex(1, 7, 3, 6, 5, 6);
            Console.WriteLine(result);
            Console.ReadLine();
        }
        public static int PivotIndex(params int[] nums)
        {
            int rightsum = 0;
            foreach (var num in nums)
            {
                rightsum += num;
            }
            int leftsum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                rightsum = rightsum - nums[i];

                if (rightsum == leftsum)
                    return i;

                leftsum = leftsum + nums[i];
            }
            return -1;


        }
        //Brute Force Approach
        public static  int PivotIndexBruteForceApp(params int[] nums)
        {
            int len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                int tempi = 0, tempEnd = len - 1, rightsum = 0, leftsum = 0;
                while (tempi < i)
                {
                    leftsum = leftsum + nums[tempi++];
                }
                while (tempEnd > i)
                {
                    rightsum += nums[tempEnd--];
                }
                if (leftsum == rightsum)
                    return i;
            }
            return -1;
        }
    }
}
