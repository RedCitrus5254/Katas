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

        public static bool ContainsDigitInNumber(
            int number,
            int digit)
        {
            while (number != 0)
            {
                if (number % 10 == digit)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }
    }
}