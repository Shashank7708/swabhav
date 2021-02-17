using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovableCar
{
    class Truck:Movable
    {
        void Movable.run()
        {
            Console.WriteLine("Truck is Moving");
        }
    }
}
