using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOfArrayExceptSelf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4 };
            var result = ProductExceptSelf(nums);
            foreach (int i in result)
                Console.Write(i + "\t");
            Console.Read();
        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            int len = nums.Length;
            int[] res = new int[len];
            int[] right = new int[len];
            int prod = 1;

            for (int i = len - 1; i >= 0; i--)
            {
                prod *= nums[i];
                right[i] = prod;
            }
            prod = 1;
            for (int i = 0; i < len - 1; i++)
            {
                int lp = prod;
                int rp = right[i + 1];

                res[i] = lp * rp;
                prod *= nums[i];
            }
            res[len - 1] = prod;
            return res;
        }


    }
}
