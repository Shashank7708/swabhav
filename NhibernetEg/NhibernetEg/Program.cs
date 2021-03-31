using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernetEg
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = Helper1.OpenSession())
            {
                using(var transaction = session.BeginTransaction())
                {
                    var car = new Car { ID = 1, Name = "BMW" };
                    session.Save(car);
                    transaction.Commit();
                    Console.WriteLine("Car");
                }

            }
            Console.ReadLine();
        }
        
    }
}
