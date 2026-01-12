using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovableCar
{
    class Bike :Movable
    {
        void Movable.run()
        {
            Console.WriteLine("Bike is Moving");
        }
    }
}
