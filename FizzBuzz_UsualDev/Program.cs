using System;

namespace FizzBuzz_UsualDev
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 1; i < 100; i++)
            {
                var message = string.Empty;
                
                if (i % 3 == 0 || HasDigitInNumber(i, 3))
                {
                    message += "Fizz";
                }

                if (i % 5 == 0 || HasDigitInNumber(i, 5))
                {
                    message += "Buzz";
                }

                if (message == string.Empty)
                {
                    message += i;
                }
                
                Console.WriteLine(message);
            }
        }

        private static bool HasDigitInNumber(int number, int digit)
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