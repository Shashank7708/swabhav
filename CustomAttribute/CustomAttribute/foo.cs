using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttribute
{
    [MyCustomAttribute(value =false)]
    class foo
    {
        
        [MyCustom]
        public bool m1()
        {
            return true;
        }
        public bool m2()
        {
            return false;
        }
        [MyCustom]
        public bool m3()
        {
            return true;
        }
        [MyCustom]
        public bool m4()
        {
            return false;
        }
    }
}