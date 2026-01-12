using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefOutParam
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 12;
            int num2 = 15;

            /*
            
            Console.WriteLine("Reference parameter eg");
            Console.WriteLine("Before passing value= " + num);
             refeg( ref num);
            Console.WriteLine("After passing value ="+ num);
            */

            Console.WriteLine("OUT parameter eg");
            Console.WriteLine("Before passing value= " + num2);
            outEg(out num2);
            Console.WriteLine("After passing value =" + num2);


            Console.ReadLine();
        }

        /*
        static void refeg(ref int num1)
        {
            num1 = num1 * 10;
        }
        */

        static void outEg(out int num1)
        {
            Console.WriteLine("i have assign value =20 in method and multiplied it by 10");
            num1 = 20;
            num1 = num1 * 10;

        }

    }
}
