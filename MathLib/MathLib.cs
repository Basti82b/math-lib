using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MathLib
{
    public class MathLib
    {
        private readonly bool _recursive;

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
            if (n == 0)
                return 1;
            RuntimeHelpers
                .EnsureSufficientExecutionStack(); // throws InsufficientExecutionStackException instead of stack overflow

            return n * RecursiveFactorial(n - 1);
        }

        private ulong LINQFactorial(uint n)
        {
            return n == 0 ? 1 : (ulong)Enumerable.Range(1, (int)n).Aggregate((i, j) => i * j);
        }

        public ulong UnevenFactorial(uint n)
        {
            return _recursive ? RecursiveUnevenFactorial(n) : LINQUnevenFactorial(n);
        }

        private ulong RecursiveUnevenFactorial(uint n)
        {
            if (n <= 1)
                return 1;
            if (n % 2 == 0)
                n--;
            RuntimeHelpers.EnsureSufficientExecutionStack();

            return n * RecursiveFactorial(n - 2);
        }

        private static ulong LINQUnevenFactorial(uint n)
        {
            return n == 0 ? 1 : (ulong)Enumerable.Range(1, (int)n).Where(x => x % 2 > 0).Aggregate((i, j) => i * j);
        }

        public ulong SquareFactorial(uint n)
        {
            return _recursive ? RecursiveSquareFactorial(n) : LINQSquareFactorial(n);
        }

        private ulong RecursiveSquareFactorial(uint n)
        {
            if (n == 0)
                return 1;
            RuntimeHelpers.EnsureSufficientExecutionStack();

            return (ulong)(Math.Pow(n, 2) * Math.Pow(RecursiveFactorial(n - 1), 2));
        }

        private ulong LINQSquareFactorial(uint n)
        {
            return n == 0 ? 1 : (ulong)Enumerable.Range(1, (int)n).Aggregate((i, j) => (int)(i * Math.Pow(j, 2)));
        }
    }
}