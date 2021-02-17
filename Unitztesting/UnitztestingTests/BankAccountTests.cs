using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unitztesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitztesting.Tests
{
    [TestClass()]
    public class BankAccountTest
    {
        [TestMethod()]
        public void DebitTesting()
        {   
            BankAccount account1 = new BankAccount("Lucy", 700);
            account1.Debit(500);
            Console.WriteLine(account1.GetBal); ;


        }
        [TestMethod()]
        public void DebitTesting1()
        {
            BankAccount account1 = new BankAccount("Maria", 600);
            account1.Debit(-199);
            Assert.Fail();
        }

    }      
    
}