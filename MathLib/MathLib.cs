namespace MathLib
{
    public class MathLib
    {
        public ulong Factorial(uint n)
        {
            return n == 0 ? 1 : n * Factorial(n - 1);
        }
    }
}