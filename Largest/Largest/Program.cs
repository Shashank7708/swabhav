using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            int[] arr = {3,2,4,6,1,9};
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] < arr[j + 1])
                    {
                        // swap temp and arr[i] 
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
            Console.WriteLine("largest "+arr[0]);
                Console.WriteLine("2nd largest "+arr[1]);
                Console.ReadLine();
            }

        }
    }
