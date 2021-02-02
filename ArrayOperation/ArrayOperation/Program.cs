using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[5];
            Console.WriteLine("Enter array element");
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    a[i] = Convert.ToInt32(Console.ReadLine());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("the array element are:");
            foreach(int i in a)
            {
                Console.Write(i+"   ");
            } 
            Console.ReadLine();

        }
    }
}
