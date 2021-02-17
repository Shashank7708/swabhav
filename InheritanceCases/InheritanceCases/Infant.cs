using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceCases
{
    class Infant :Man
    {
        public override void Play()
        {
            Console.WriteLine("Infant is Palying");
        }
        public override void Eat()
        {
            Console.WriteLine("Infant is Eating");
        }
    }
}
