using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.Services.Tests
{
    [TestClass()]
    public class MathServiceTests
    {
        [TestMethod()]
        public void DivideTest()
        {
            // Arrange
            var mathService = new MathService();
            int a = 10;
            int b = 2;
            // Act
            double result = mathService.Divide(a, b);
            // Assert
            Assert.AreEqual(5.0, result);
        }
        [TestMethod()]
        public void DivideDoubleTest()
        {
            // Arrange
            var mathService = new MathService();
            int a = 10;
            int b = 4;
            // Act
            double result = mathService.Divide(a, b);
            // Assert
            Assert.AreEqual(2.5, result);
        }

        [TestMethod()]
        public void DivideByZeroTest()
        {
            // Arrange
            var mathService = new MathService();
            int a = 10;
            int b = 0;
            // Act & Assert
            Assert.ThrowsException<DivideByZeroException>(() => mathService.Divide(a, b));
        }
    }
}