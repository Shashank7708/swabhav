using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorEg
{
    class Constructor1
    {
        internal Constructor1()
        {
            Console.WriteLine("helli i am in no argument and private");
        }

        internal Constructor1(int a)
        {
            Console.WriteLine("the value is "+a);
        }
    }
}
