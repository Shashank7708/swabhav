using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerWithMostWater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            Program p=new Program();
             var result=p.MaxArea(arr);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public  int MaxArea(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;
            //  int l,r,
            int result = 0;
            while (left < right)
            {
                int currentHeight = Math.Min(height[left], height[right]);
                int currentWidth = right - left;
                if (result < (currentHeight * currentWidth))
                {
                    result = currentHeight * currentWidth;
                    // l=left;
                    //  r=right;
                }

                if (height[left] < height[right])
                    left++;
                else
                    right--;

            }
            return result;
        }
    }
}
