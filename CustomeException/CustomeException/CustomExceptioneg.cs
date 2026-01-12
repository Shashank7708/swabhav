using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomeException
{
    class CustomExceptioneg :Exception
    {
        public override string Message
        {
            get { return "exception:Name Cannot Be Sachin"; }
        }

    }
}
