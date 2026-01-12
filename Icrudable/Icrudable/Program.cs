using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icrudable
{
    class Program
    {
        static void Main(string[] args)
        {
            Icrudable adb = new AddressDB();
            Icrudable cdb = new CustomerDB();
            Icrudable idb = new InvoiceDB();
            PrintInfo(adb);
            PrintInfo(idb);
            PrintInfo(cdb);
            Console.Read();
            
        }
         static void PrintInfo(Icrudable c)
        {
            c.create();
            c.read();
            c.delete();
            c.update();
        }
    }
}
