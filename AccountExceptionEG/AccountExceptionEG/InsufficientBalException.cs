using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountExceptionEG
{
    class InsufficientBalException :Exception
    {
        public override string Message
        {
            get { return "Insufficient Balance"; }
        }
    }
}
