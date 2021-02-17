using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equals
{
    class Object
    {
        int breadth;
        int height;
        public virtual void Check(int a ,int b)
        {
            this.height = a;
            this.breadth = b;

        }
    }
}
