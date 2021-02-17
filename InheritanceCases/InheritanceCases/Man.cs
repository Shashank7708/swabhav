using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceCases
{
    class Man
    {
        public  virtual void  Play()
        {
            Console.WriteLine("Man is Palying");
        }
        public virtual void Eat()
        {
            Console.WriteLine("Man is Eating");
        }
    }
}
