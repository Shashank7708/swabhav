using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenOddPrimeWithFunction1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] even = new int[5];
            int[] odd = new int[5];
            int[] prime = new int[5];

            int[] num = new int[args.Length];
            Console.WriteLine("In args: ");
            foreach (String i in args)
            {
                Console.Write(i + "  ");
            }
            Console.WriteLine();
            for (int i = 0; i < args.Length - 1; i++)
            {
                num[i] = int.Parse(args[i]);
            }
            int j = 0;
            int k = 0;
            foreach (int i in num)
            {
                if (i % 2 == 0) { even[j++] = i; }
                else
                {
                    odd[k++] = i;
                }

            }
            int addtoprime = 0;
            foreach (int i in num)
            {

                int count = 0;
                for (int q = 2; q < i; q++)
                {
                    if (i % q == 0)
                        count++;
                }
                if (count == 0)
                {
                    prime[addtoprime++] = i;
                }
            }
            string str = args[args.Length - 1];
            if (str == "e")
            {
                even1(even);

            }
            else if (str == "o")
            {
                odd1(odd);
            }

            else if (str == "p")
            {
                prime1(prime);
            }
            else
            {
                Console.WriteLine("Another value=" + str);
            }



            Console.ReadLine();
        }


        static void even1(int[] even2)
        {
            Console.Write("Even no. are= ");
            foreach (int i in even2)
            {
                if (i != 0)
                    Console.Write(i + "  ");
            }
        }


        static void odd1(int[] odd2)
        {
            Console.Write("Odd  no. are= ");
            foreach (int i in odd2)
            {
                if (i != 0)
                    Console.Write(i + "  ");
            }

        }

        static void prime1(int[] prime2)
        {
            Console.Write("prime  no. are= ");
            foreach (int i in prime2)
            {
                if (i != 0)
                    Console.Write(i + "  ");
            }
        }

    }
}
        
    

