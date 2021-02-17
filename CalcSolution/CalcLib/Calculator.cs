using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLib
{
    public class Calculator
    {
        public bool CheckEven (int numtoCheck)
        {
            if (numtoCheck % 2 == 0)
                return true;
            return false;
        }
        public bool CheckOdd(int numtoCheck)
        {
            if (numtoCheck % 2 != 0)
                return true;
            return false;
        }
        



    }
}
