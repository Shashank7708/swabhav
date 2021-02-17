using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceBehaviour
{
    class Child : Parent
    {
        public int foo;
        public Child(int foo):base(10)
        {
            this.foo = foo;
            Console.WriteLine(this.foo);
        }

        public int getValue()
        {
            return this.foo;
        }
    }
}
