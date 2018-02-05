﻿using System;
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
            var calc = new Calc();
            int x = 10;
            int y = 5;

            //Act
            var result = calc.Sub(x,y);

            //Assert
            Assert.AreEqual(5, result);
        }
    }
}