using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Rectangle r1 = new Rectangle();
            r1.setvalue(10, 20);
            PrintInfo(r1);
            Rectangle r2 = new Rectangle();
            
            r2.setvalue(30, 40);
            PrintInfo(r2);

            */

            Console.WriteLine("Adress   " + new Rectangle());
            Console.WriteLine("Adress   " + new Rectangle());

            new Rectangle().setvalue(10, 20);
            Console.WriteLine("Height  " + new Rectangle().getHeight());
            Console.WriteLine("Width   " + new Rectangle().getWidth());

            Console.ReadLine();

        }
        /*
        public static void PrintInfo(Rectangle r)
        {
            Console.WriteLine("Width= " + r.getHeight() + "\n height= "+r.getHeight());
            Console.WriteLine("\n\n");
        }
        */
    }
}
