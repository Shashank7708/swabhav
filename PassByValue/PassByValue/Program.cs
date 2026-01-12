using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassByValue
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 20, 30, 40 };
            printValue(arr);
            for(int i= 0; i<=3; i++){
                Console.WriteLine(arr[i]);
            }
            Console.ReadLine();
       
        }
        static void printValue(int[] arr)
        {
            for(int i = 0; i <= 3; i++)
            {
                arr[i] = 0;
            }
        }
    }
}
