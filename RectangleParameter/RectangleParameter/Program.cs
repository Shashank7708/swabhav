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
        {
            Rectangle r1 = new Rectangle();
            Console.WriteLine("CASE1:   Without Setting any data");
            Console.WriteLine("String value:  "+r1.color);
            Console.WriteLine("int value:  "+r1.height);
            CaseSeperator();


            
            Rectangle2 r2 = new Rectangle2(4,5,"Red");
            Console.WriteLine("Case 2 :Setting and Fetching value\n");
            Console.WriteLine("Height= " + r2.height + "\t width= " + r2.width + "\tcolor=" + r2.color);
            CaseSeperator();


            Console.WriteLine("Case 3 :Setting private value and Fetching usinf methods\n");
            Rectangle3 r3 = new Rectangle3();
            r3.returnHeight = 10;
            r3.returnWidth = 20;
            r3.returnColor = "blue";
            Console.WriteLine("Height= " + r3.returnHeight+"\t width= " + r3.returnWidth + "\tcolor=" + r3.returnColor);
            CaseSeperator();

            Console.WriteLine("Case 4 & 5: Rectangle width and height between 1 to 100 & only color =red,green,blue");
            Rectangle4 r4 = new Rectangle4();
            r4.PropertyColor = "Green";
            r4.PropertyHeight = 5;
            r4.PropertyWidth = 6;
            Console.WriteLine("Height= " + r4.PropertyHeight + "\t width= " + r4.PropertyWidth+ "\tcolor=" + r4.PropertyColor );
            CaseSeperator();
            Rectangle4 r5 = new Rectangle4();
            r5.PropertyColor = "Violet";
            r5.PropertyHeight = 10;
            r5.PropertyWidth = 40;
            
            Console.WriteLine("Height= " + r5.PropertyHeight + "\t width= " + r5.PropertyWidth+ "\tcolor=" + r5.PropertyColor);
            CaseSeperator();
            
         
            Console.ReadLine();


        }

        static void CaseSeperator()
        {
            Console.WriteLine("*****************************************");
        }
    }
}
