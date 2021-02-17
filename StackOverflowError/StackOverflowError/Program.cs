using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowError
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StackOverflowError stackoverflowerr = new StackOverflowError();
                stackoverflowerr.add();
            }
            catch(StackOverflowException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
