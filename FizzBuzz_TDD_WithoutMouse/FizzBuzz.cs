using System;

namespace FizzBuzz_TDD_WithoutMouse
{
    public class FizzBuzz
    {
        public void Start(
            int count)
        {
            for (int i = 1; i < count; i++)
            {
                var message = string.Empty;

                if (MathHelper.IsDividedByNumber(
                    divisible: i,
                    divisor: 3))
                {
                    message += "Fizz";
                }

                if (MathHelper.IsDividedByNumber(
                    divisible: i,
                    divisor: 5))
                {
                    message += "Buzz";
                }

                if (string.IsNullOrWhiteSpace(message))
                {
                    message += i;
                }

                Console.WriteLine(message);
            }                   
        }

    }
}