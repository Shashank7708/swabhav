using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleParameter
{
    class Program
    {
        static void Main(string[] args)
        {   /*Cas1: Wihout Setting any value
            Rectangle r1 = new Rectangle();
            Console.WriteLine("CASE1:   Without Setting any data");
            Console.WriteLine("String value:  "+r1.color);
            Console.WriteLine("int value:  "+r1.height);

            */

            /* CASE2  AND CASE3
            Rectangle2 r2 = new Rectangle2(4,5,"Red");
            Console.WriteLine("Case 2 :Setting and Fetching value\n");
            Console.WriteLine("Height= " + r2.height + "\t width= " + r2.width + "\tcolor=" + r2.color+"\n\n\n\n");



            Console.WriteLine("Case 3 :Setting private value and Fetching usinf methods\n");
            Rectangle3 r3 = new Rectangle3(40,45,"Violet");
            Console.WriteLine("Height= " + r3.returnHeight()+"\t width= " + r3.returnWidth() + "\tcolor=" + r3.returnColor() + "\n\n\n\n");
            */

            Console.WriteLine("Case 4 & 5: Rectangle width and height between 1 to 100 & only color =red,green,blue");
            Rectangle4 r4 = new Rectangle4(45, 200, "Red");
            Console.WriteLine("Height= " + r4.height + "\t width= " + r4.width + "\tcolor=" + r4.color + "\n\n\n\n");

            Rectangle4 r5 = new Rectangle4(1200, 65, "Violet");
            Console.WriteLine("Height= " + r5.height + "\t width= " + r5.width+"\tcolor=" + r5.color + "\n\n\n\n");


            Console.ReadLine();


        }
    }
}
