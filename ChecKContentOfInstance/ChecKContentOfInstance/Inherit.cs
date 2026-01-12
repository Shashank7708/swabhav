using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChecKContentOfInstance
{
    class Inherit
    {
        private string name;
        
        public void Getname(string name)
        {
            this.name = name;

        }
        public override bool Equals(object obj)
        {
            Inherit n1 = (Inherit)obj;
            int ha = n1.GetHashCode;
            if (ha.name.Equals(this.name))
                return true;
            return false;
        }
    }
}
