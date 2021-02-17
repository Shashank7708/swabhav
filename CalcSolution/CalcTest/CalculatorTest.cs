using CalcLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalcTest
{
    [TestClass]
    public class CalculatorTest
    {
        private object expected;
        private object actual;

        [TestMethod]
        public void CheckEven()
        {
            //
            int num = 2;
            Calculator c = new Calculator();
            bool iseven = c.CheckEven(num);
            bool isodd = c.CheckOdd(num);

            Assert.AreEqual(expected, actual);
            Console.WriteLine(iseven);
            Console.WriteLine(isodd);
        }
    }
}
