using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("List Eg:");
            Console.WriteLine("Product Details:");
            Product[] product = new Product[6];
            for (int i = 0; i < product.Length; i++)
            {
                product[i] = new Product();
            }
            product[0].Item(101, "Rice", 34.5f, 10);
            product[1].Item(102, "Wheat", 30f, 10);
            product[2].Item(103, "Maggi", 15f, 5);
            product[3].Item(104, "Sause", 15f, 2);
            product[4].Item(103, "Parle", 10f, 5);
            product[5].Item(103, "Bread", 5f, 5);
            Dictionary<int,object> productList = new Dictionary<int,object>();
            int count = 0;
            foreach (Product i in product)
            {
                productList.Add(count++,i);
            }
            Console.WriteLine("Id   Name    PerUnit Quantity     Total");
            foreach (var i in productList)
            {
                Console.WriteLine("{0}  {1}    {2}      {3}           {4}",i.Value.;
            }
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("GrandTotal: " + product[5].GetGrandTotal());
            Console.WriteLine("Welcome! Do Shop Again");
            Console.ReadLine();
        }
    }
}
