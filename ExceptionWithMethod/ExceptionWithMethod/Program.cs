using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExceptionWithMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            m1();
            Console.WriteLine("ENd of the Program");

            Console.Read();
        }
        static void m1()
        {
            Console.WriteLine("m1 is called");
            m2();
        }
        static void m2()
        {
            Console.WriteLine("m2 is called");
            m3();
        }
        static void m3()
        {
            Console.WriteLine("m3 is called");
            try
            {
                throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("End of the m3");
            }
        }

    }
}
