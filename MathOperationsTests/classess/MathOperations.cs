using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MathOperationsTests.classess {

    public class MathOperations {
        public int Add(int a, int b) {
            return checked(a + b);
        }
        public int Subtract(int a, int b) {
            return checked(a - b);
        }
        public int Multiply(int a, int b) {
            return a * b;

        }
        public int Divide(int a, int b) {
            if (b <= 0) {
                throw new DivideByZeroException("you can't divide by zero!");
            } else {
                return a / b;
            }
        }
        public double SquareRoot(double number) {
            if (number <= 0) {
                throw new ArgumentOutOfRangeException("you can't square negative number");
            } else {
                return Math.Sqrt(number);
            }
        }


    }
}
