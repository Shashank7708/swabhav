using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icrudable
{
    class AddressDB : Icrudable
    {
        void Icrudable.create()
        {
              Console.WriteLine("Address DB is Creating");
        }
        void Icrudable.read()
        {
            Console.WriteLine("Address DB is Reading");
        }
       void Icrudable.update()
        {
            Console.WriteLine("Address DB is Reading");
        }
       void Icrudable.delete()
        {
            Console.WriteLine("Address DB is Reading");
        }
    }
}
