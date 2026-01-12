using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structureeg
{
    struct Books
    {
        public int y;
        public int x;
        void getValue(int a, int b)
        {
            x = a;
            y = b;
        }



        class Program
        {
            static void Main(string[] args)
            {
                Books b1 = new Books();
                b1.getValue(10, 20);
                modify();
                Console.WriteLine(b1.x + "  "+b1.y);
                Console.ReadLine();

            }
          public  static void modify()
            {
                
            }
        }
    }
}
