using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveZeros283
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 0, 1, 0, 3, 12 };
            foreach (int n in nums)
                Console.Write(n + "\t");
            MoveZeroesApp2(nums);
            Console.WriteLine("\n\nAfter Performing the operation\n");
            foreach (int n in nums)
                Console.Write(n + "\t");
            Console.Read();
        }

        public static void MoveZeroesApp2(int[] nums)
        {
            int nonzeroPointer = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    (nums[i], nums[nonzeroPointer]) = (nums[nonzeroPointer], nums[i]);
                    nonzeroPointer++;
                }
            }
        }
        
       public static void MoveZeroesApp1(int[] nums) {

           int counter=0;
           if(nums.Length==0)
               return;
           for(int i=0;i<nums.Length;i++){
               if(nums[i]!=0)
                   nums[counter++]=nums[i];
           }
           for(int i=counter;i<nums.Length;i++)
               nums[i]=0;
       }
       
    }
}
