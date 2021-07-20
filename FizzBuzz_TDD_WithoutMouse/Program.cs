using System;

namespace FizzBuzz_TDD_WithoutMouse
{
    class Program
    {
        static void Main(string[] args)
        {
            var fizzBuzz = new FizzBuzz();
            fizzBuzz.Start(
                count: 100);
        }
    }
}