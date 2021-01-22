using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("duplicate values are as follow:");
            int[] arr = { 2, 4, 5, 20, 2, 80, 80 };
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        Console.WriteLine(arr[j]);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
