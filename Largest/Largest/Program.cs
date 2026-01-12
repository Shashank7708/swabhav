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
            for (int i = 0; i < n -1; i++)
                for (int j = i+1; j < n; j++)
                    if (arr[i] < arr[j])
                    {
                        // swap temp and arr[i] 
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
            Console.WriteLine("largest "+arr[0]);
                Console.WriteLine("2nd largest "+arr[1]);
                Console.ReadLine();
            }

        }
    }
