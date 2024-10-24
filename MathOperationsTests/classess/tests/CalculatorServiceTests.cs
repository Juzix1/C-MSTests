using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperationsTests.classess.tests {
    [TestClass]
    public class CalculatorServiceTests {

        [TestMethod]
        public void PerformAddition_ReturnsCorrectResult() {
            var mockCalculator = new Mock<ICalculator>();
            mockCalculator.Setup(c => c.Add(It.IsAny<float>(), It.IsAny<float>())).Returns(5);

            var calculatorService = new CalculatorService(mockCalculator.Object);

            int result = (int)calculatorService.PerformAddition(2, 3);

            Assert.AreEqual(5, result);
        }
    }
}
