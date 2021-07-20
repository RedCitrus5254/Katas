namespace FizzBuzz_TDD_WithoutMouse
{
    public static class MathHelper
    {
        public static bool IsDividedByNumber(
            int divisible,
            int divisor)
        {
            if (divisible % divisor == 0)
            {
                return true;
            }

            return false;
        }
    }
}