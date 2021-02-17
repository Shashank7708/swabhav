using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackProduct
{
   public class Product
    {
        private int id;
        private string name;
        private double unitPrice;
        private int quantity;
        private static double grandtotle = 0;
        public double total = 0;
        public void Item(int id, string name, double unitprice, int quantity)
        {
            this.id = id;
            this.name = name;
            this.unitPrice = unitprice;
            this.quantity = quantity;
            this.total = this.total + unitPrice * quantity;

            grandtotle = grandtotle + unitPrice * quantity;

        }

        public int Getid()
        {
            return this.id;
        }

        public string GetName()
        {
            return this.name;

        }

        public int GetQuantity()
        {
            return this.quantity;
        }
        public double GetUnitPrice()
        {
            return this.unitPrice;
        }
        public double GetGrandTotal()
        {
            return grandtotle;
        }

    }
}
