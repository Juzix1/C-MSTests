using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathOperationsTests.classess;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MathOperationsTests.classess.tests {

    [TestClass]
    public class MathOperationsTests {
        private MathOperations cal;

        [TestInitialize]
        public void Init() {
            cal = new MathOperations();
        }

        [TestCleanup]
        public void Cleanup() {
            cal = null;
        }


        [TestMethod]
        [DataRow(2, 3, 5)]
        [DataRow(323, 532, 855)]
        public void TestAddition(int a, int b, int expected) {

            var result = cal.Add(a, b);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        [DataRow(-554, 223, -331)]
        public void TestAdditionMinus(int a, int b, int expected) {

            var result = cal.Add(a, b);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestAdditionMaxInt() {
            int maxValue = int.MaxValue;

            Assert.ThrowsException<OverflowException>(() => cal.Add(maxValue, maxValue));
        }

        [TestMethod]
        public void TestSubtraction() {

            var result = cal.Subtract(8, 4);

            Assert.AreEqual(4, result);
        }
        [TestMethod]
        public void TestSubtractionMinInt() {
            int minValue = int.MinValue;
            Assert.ThrowsException<OverflowException>(() => cal.Subtract(minValue, 1));
        }
        [TestMethod]
        public void TestSubtractionMinus() {

            var result = cal.Subtract(-8, 4);

            Assert.AreEqual(-12, result);
        }
        [TestMethod]
        public void TestMultiplication() {

            var result = cal.Multiply(2, 3);

            Assert.AreEqual(6, result);
        }
        [TestMethod]
        public void TestMultiplicationByZero() {
            var cal = new MathOperations();

            var result = cal.Multiply(2, 0);

            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void TestDivide() {

            var result = cal.Divide(4, 2);

            Assert.AreEqual(2, result);
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivideByZero() {
            var result = cal.Divide(5, 0);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        [DataRow(49, 7)]
        [DataRow(2116, 46)]
        public void TestSquareRoot(int a, int expected) {
            var result = cal.SquareRoot(a);
            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSquareRootNegative() {
            var result = cal.SquareRoot(-4);

        }
        [TestMethod]
        [DataRow(10000)]
        [DataRow(100000)]
        [DataRow(1000000)]
        public void TestMultiplicationTime(int iterations) {

            var stopwatch = new Stopwatch();
            int a = 23;
            int b = 315;
            stopwatch.Start();

            for (int i = 0; i < iterations; i++) {
                cal.Multiply(a, b);
            }
            stopwatch.Stop();
            Console.WriteLine($"Iterations: {iterations}, Time taken: {stopwatch.ElapsedMilliseconds} ms");
        }

        [TestMethod]
        [DataRow(1000000)]
        public void ParallelMultiplicationTime(int iterations) {
            
            var stopwatch = new Stopwatch();
            int a = 23;
            int b = 12;

            stopwatch.Start();
            for (int i = 0; i < iterations; i++) {
                cal.Multiply(a, b);
            }
            stopwatch.Stop();
            Console.WriteLine($"Sequence Multiply: {stopwatch.ElapsedMilliseconds} ms");
            // Parallel Multiply
            stopwatch.Restart();
            Parallel.For(0, iterations, i => {
                cal.Multiply(a, b);
            });
            stopwatch.Stop();
            Console.WriteLine($"Parallel Multiply: {stopwatch.ElapsedMilliseconds} ms");

        }

    }
}
