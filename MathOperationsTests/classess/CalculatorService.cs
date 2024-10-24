using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace MathOperationsTests.classess {
    internal class CalculatorService {

        private readonly ICalculator _calculator;

        public CalculatorService(ICalculator calculator) {

            _calculator = calculator;
        }

        public float PerformAddition(float a, float b) {
            return _calculator.Add(a, b);
        }
    }
}
