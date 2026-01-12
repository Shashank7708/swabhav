using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    class Bank
    {
        int accountno;
        string name;
        float balance;

        public Bank(int a,string n,float balance)
        {
            accountno = a;
            name = n;
            this.balance = balance;
        }

        public float getBalance()
        {
            return balance;
        }
        public int getAccountno()
        {
            return accountno;
        }
       public void withdraw(float withdrawalAmt)
        {

            balance = balance - withdrawalAmt;
        }

        public void deposit(float depositAmt)
        {
            balance = balance + depositAmt;
        }

    }
}
