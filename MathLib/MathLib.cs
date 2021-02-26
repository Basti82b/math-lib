using System.Linq;

namespace MathLib
{
    public class MathLib
    {
        private bool _recursive;

        public MathLib(bool recursive = false)
        {
            _recursive = recursive;
        }

        public ulong Factorial(uint n)
        {
            return _recursive ? RecursiveFactorial(n) : LINQFactorial(n);
        }

        private ulong RecursiveFactorial(uint n)
        {
            return n == 0 ? 1 : n * RecursiveFactorial(n - 1);
        }

        private ulong LINQFactorial(uint n)
        {
            return n == 0 ? 1 : (ulong)Enumerable.Range(1, (int)n).Aggregate((i, j) => i * j);
        }
    }
}