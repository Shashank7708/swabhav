using AccountExceptionEG;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace WithdrawTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Account a = new Account();
            a.withdraw(450);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Account a = new Account();
            a.withdraw(4500);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Account a = new Account();
            a.withdraw(45323);
        }
    }
}
