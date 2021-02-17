using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomeException
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a name");
            int count = 0;
            while (count < 3)
            {
                try
                {
                    string name = Console.ReadLine();
                    string SmallCaseName = name.ToLower();
                    if (SmallCaseName == "sachin")
                    {
                        throw new CustomExceptioneg();
                    }
                }
                catch (CustomExceptioneg e)
                {
                    Console.WriteLine(e.Message);
                }
                count++;
            }
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine(c);
            Console.WriteLine("Out of Try Catch");
            Console.ReadLine();

        }
    }
}
