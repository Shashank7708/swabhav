using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            int checkpalindrom,temp,total=0;
            Console.WriteLine("enter a no ");
            checkpalindrom = Convert.ToInt32(Console.ReadLine());
            temp = checkpalindrom;
            while (temp > 0)
            {
                int temp2  = temp % 10;
                total = total * 10 + temp2;
                temp = temp / 10;
                
            }
            if (total == checkpalindrom)
            {
                Console.WriteLine("IT is palindrome");

            }
            else
            {
                Console.WriteLine("It is no palindrome");
            }
            Console.ReadLine();
        }
    }
}
