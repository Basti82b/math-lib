using System.Linq;

namespace MathLib
{
    public class MathLib
    {
        public ulong Factorial(uint n)
        {
            return n == 0 ? 1 : (ulong)Enumerable.Range(1, (int)n).Aggregate((i, j) => i * j);
        }
    }
}