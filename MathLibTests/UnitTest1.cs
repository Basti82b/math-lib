using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MathLibTests
{
    /// <summary>
    /// https://docs.microsoft.com/de-de/visualstudio/test/quick-start-test-driven-development-with-test-explorer?view=vs-2019
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        private bool _recursive;

        [TestMethod]
        public void BasicFactorialTest()
        {
            // Create an instance to test:
            var mathLib = new MathLib.MathLib(_recursive);

            // Define a test input and output value:
            var expectedResult = 1;
            var input = 0u;

            // Run the method under test:
            var actualResult = mathLib.Factorial(input);

            // Verify the result:
            Assert.AreEqual(expectedResult, actualResult, expectedResult / 1000);
        }

        [TestMethod]
        public void FactorialValueRangeTest()
        {
            // Create an instance to test.
            var mathLib = new MathLib.MathLib(_recursive);

            uint[] expectedResults = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800 };

            // Try a range of values.
            for (var i = 0u; i < expectedResults.Length; i++)
            {
                // Run the method under test:
                var actualResult = mathLib.Factorial(i);
                // Verify the result:
                Assert.AreEqual(expectedResults[i], actualResult, delta: expectedResults[i] / 1000);
            }
        }

        [TestMethod]
        public void RecursiveFactorialTest()
        {
            _recursive = true;
            FactorialValueRangeTest();
        }

        [TestMethod]
        public void LINQFactorialTest()
        {
            _recursive = false;
            FactorialValueRangeTest();
        }

        [TestMethod]
        public void UnevenFactorialTest()
        {
            // Create an instance to test:
            var mathLib = new MathLib.MathLib();

            // Define a test input and output value:
            var expectedResult = 7 * 5 * 3 * 1;
            var input = 8u;

            Test(mathLib, expectedResult, input);

            expectedResult = 9 * 7 * 5 * 3 * 1;
            input = 9u;

            Test(mathLib, expectedResult, input);

            static void Test(MathLib.MathLib mathLib, int expectedResult, uint input)
            {
                // Run the method under test:
                var actualResult = mathLib.UnevenFactorial(input);

                // Verify the result:
                Assert.AreEqual(expectedResult, actualResult, expectedResult / 1000);
            }
        }

        [TestMethod]
        public void RecursiveUnevenFactorialTest()
        {
            _recursive = true;
            UnevenFactorialTest();
        }

        [TestMethod]
        public void LINQUnevenFactorialTest()
        {
            _recursive = false;
            UnevenFactorialTest();
        }

        [TestMethod]
        public void SquareFactorialTest()
        {
            // Create an instance to test:
            var mathLib = new MathLib.MathLib();

            // Define a test input and output value:
            var expectedResult = Math.Pow(3, 2) * Math.Pow(2, 2);
            var input = 3u;

            // Run the method under test:
            var actualResult = mathLib.SquareFactorial(input);

            // Verify the result:
            Assert.AreEqual(expectedResult, actualResult, expectedResult / 1000);
        }

        [TestMethod]
        public void RecursiveSquareFactorialTest()
        {
            _recursive = true;
            SquareFactorialTest();
        }

        [TestMethod]
        public void LINQSquareFactorialTest()
        {
            _recursive = false;
            SquareFactorialTest();
        }
    }
}