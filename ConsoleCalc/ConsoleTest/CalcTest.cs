using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCalc;

namespace ConsoleTest
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void TestSub()
        {
            //Arrange
            int x = 10;
            int y = 5;
            var calc = new Calc();

            //Act
            var result = calc.Sub(x, y);

            //Assert
            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void TestSum()
        {
            double x = 5.2;
            double y = 2.8;
            var calc = new Calc();

            var result = calc.Sum(x, y);

            Assert.AreEqual(8.0, result);
        }

        [TestMethod]
        public void TestMul()
        {
            double x = 2.5;
            double y = 3.5;
            var calc = new Calc();

            var result = calc.Multiplication(x, y);

            Assert.AreEqual(8.75, result);
        }

        [TestMethod]
        public void TestDiv()
        {
            double x = 6.0;
            double y = 1.5;
            var calc = new Calc();

            var result = calc.Division(x,y);

            Assert.AreEqual(4.0, result);
        }
    }
}
