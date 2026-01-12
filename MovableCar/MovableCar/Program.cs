using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovableCar
{
    class Program
    {
        static void Main(string[] args)
        {
            Movable[] m1 = new Movable[3];
            m1[0] = new Truck();
            m1[1] = new Bike();
            m1[2] = new Car();
            
            foreach (Movable j in m1)
                PrintInfo(j);
            
            
            Console.Read();
        }
        static void PrintInfo(Movable m)
        {
            m.run();
        }
    }
}
