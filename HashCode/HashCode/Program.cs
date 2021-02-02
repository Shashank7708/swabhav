using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            hash c1 = new hash();
            c1.setvalue(10, 20);
            Console.WriteLine("h1 hashacode=" + c1.GetHashCode);

            hash c2;
            c2 = c1;
            c2.setvalue(c2.getHeight+1,c2.getWidth+1);
            Console.WriteLine("h1 hashacode=" + c1.GetHashCode);
            Console.WriteLine("h1 hashacode=" + c1.GetHashCode);

        }
    }
}
