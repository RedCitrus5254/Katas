namespace FizzBuzz_WithoutMouse
{
    using System;

    public class FizzBuzz
    {
        public void Start(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var message = "";
                
                if (IsDivisibleByDigit(i, 3) || HasDigitInNumber(i, 3))
                {
                    message += "Fizz";
                }

                if (IsDivisibleByDigit(i, 5) || HasDigitInNumber(i, 5))
                {
                    message += "Buzz";
                }

                if (string.IsNullOrEmpty(message))
                {
                    message += i;
                }

                Console.WriteLine(message);
            }
        }

        private bool IsDivisibleByDigit(
            int number,
            int digit)
        {
            if (number % digit == 0)
            {
                return true;
            }

            return false;
        }

        private bool HasDigitInNumber(
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