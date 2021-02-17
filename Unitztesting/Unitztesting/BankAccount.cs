using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitztesting
{
    public class BankAccount
    {

        string customerName;
        double bal;

        public BankAccount(string customername, double bal)
        {
            this.customerName = customername;

            this.bal = bal;

        }
        public double GetBal { get { return this.bal; } }
        public bool Debit(double amt)
        {                                      
            
            if (amt >= 0)
            {
                return false;
            }
            else if (bal - amt < 500)
            {
                return false;
            }
            bal -= amt;
            Console.WriteLine("Transaction Successfull");
            return true;
        }
        public void Credit(double amt)
        {
            if (amt <= 0)
            {
                throw new Exception("Invalid Input");
            }
            bal += amt;
            Console.WriteLine("Transaction Successfull");
        }
    }
}
