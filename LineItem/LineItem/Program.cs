using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineItem
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = Helper13.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var customer = new Customer { name = "Donkey", address = "Andheri" };
                    var order = new Order { Oname = "YBCO12" };
                    var lineitem = new LineItem { Itemname = "Java", PerCost = 122, quantity = 1 };

                    lineitem.Order = order;
                    
                    if (order is Order)
                    {
                        order.LineItem.Add(lineitem);
                    }
                    order.Customer = customer;
                    customer.Order.Add(order);
                    session.Save(lineitem);
                    session.Save(order);

                    session.Save(customer);
                    transaction.Commit();
                    Console.WriteLine("Done");

                }
            }
            Console.ReadLine();
        }
    }
}
