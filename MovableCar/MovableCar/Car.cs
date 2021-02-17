using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovableCar
{
    class Car :Movable
    {
        void Movable.run()
        {
            Console.WriteLine("Car is Moving");
        }
    }
}
