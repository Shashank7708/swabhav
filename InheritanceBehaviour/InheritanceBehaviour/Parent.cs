using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceBehaviour
{
    class Parent
    {
        int foo;
        public Parent(int foo)
        {
            this.foo = foo;
            Console.WriteLine(this.foo);
        }

        public int getvalue()
        {
            return this.foo;
        }
    }
}
