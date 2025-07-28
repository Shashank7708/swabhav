using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class Foo
    {
        public delegate void FooDelegate();
        public event FooDelegate FooEvent;

        public Foo()
        {

        }

        public void Run()
        {
            if (FooEvent != null)
            {
                FooEvent();
            }
        }
    }
}
