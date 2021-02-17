using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icrudable
{
    class CustomerDB :Icrudable
    {
        void Icrudable.create()
        {
            Console.WriteLine("Customer DB is Creating");
        }
        void Icrudable.read()
        {
            Console.WriteLine("Customer DB is Reading");
        }
        void Icrudable.update()
        {
            Console.WriteLine("Customer DB is Reading");
        }
        void Icrudable.delete()
        {
            Console.WriteLine("Customer DB is Reading");
        }
    }
}
