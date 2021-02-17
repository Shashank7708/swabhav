using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrowAndThrowEx
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Exception1();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception 1:");
                Console.WriteLine(e.StackTrace.ToString());
            }
            Console.ReadLine();
        }

        public static void Exception1()
        {
            try
            {
                DivByZero();
            }
            catch
            {
                throw;
            }
            
        }


        public static void DivByZero()
        {
            int x = 0;
            int y = 4 / x;
        }
    }
}
