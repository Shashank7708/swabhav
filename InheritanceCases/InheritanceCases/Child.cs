using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceCases
{
    class Child : Man
    {
        public override void Play()
        {
            Console.WriteLine("Child is Palying");
        }
        public override void Eat()
        {
            Console.WriteLine("Child is Eating");
        }
    }
}
