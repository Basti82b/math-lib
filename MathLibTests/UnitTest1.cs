using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathLibTests
{
    /// <summary>
    /// https://docs.microsoft.com/de-de/visualstudio/test/quick-start-test-driven-development-with-test-explorer?view=vs-2019
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        private uint[] _expectedResults = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800 };
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

            // Try a range of values.
            for (var i = 0u; i < _expectedResults.Length; i++)
            {
                // Run the method under test:
                var actualResult = mathLib.Factorial(i);
                // Verify the result:
                Assert.AreEqual(_expectedResults[i], actualResult, delta: _expectedResults[i] / 1000);
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
    }
}