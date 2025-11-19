using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int r = gcd(64, 57);
            Console.WriteLine(r);

            //GCD of Array
            int[] arr = new int[] { 64, 40, 16 };
            int result = arr[0];
            for(int i = 1; i < arr.Length; i++)
            {
                result=gcd(result, arr[i]);
            }
            Console.WriteLine(result);

            Console.ReadLine();
        }
        static int gcd(int a, int b)
        {
            while (b % a != 0)
            {
                int r = b % a;
                b = a;
                a = r;
            }
            return a;
        }



    }
}
