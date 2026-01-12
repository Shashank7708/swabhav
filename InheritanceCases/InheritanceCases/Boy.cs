using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceCases
{
    class Boy : Man
    {
        public override void Play()
        {
            Console.WriteLine("Boy is Palying");
        }
        public override void Eat()
        {
            Console.WriteLine("Boy is Eating");
        }
    }
}
