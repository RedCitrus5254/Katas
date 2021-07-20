using FizzBuzz_TDD_WithoutMouse;
using FluentAssertions;
using Xunit;

namespace FizzBuzz_TDD_WithoutMouseTests
{
    public class MathHelperTests
    {
        public class IsDividedByNumberTests
        {
            [Theory]
            [InlineData(5, 2, false)]
            [InlineData(10, 3, false)]
            [InlineData(345, 21, false)]
            [InlineData(10, 5, true)]
            [InlineData(24, 12, true)]
            [InlineData(6, 3, true)]
            public void ShouldReturnsCorrectResult(
                int divisible,
                int divisor,
                bool result)
            {
                MathHelper
                    .IsDividedByNumber(
                        divisible: divisible,
                        divisor: divisor)
                    .Should()
                    .Be(result);
            }    
        }


        public class ContainsDigitInNumber
        {
            [Theory]
            [InlineData(1234, 5, false)]
            [InlineData(123, 8, false)]
            [InlineData(190, 2, false)]
            [InlineData(53, 5, true)]
            [InlineData(1234, 1, true)]
            [InlineData(32, 2, true)]
            [InlineData(7, 7, true)]
            public void ShouldReturnsCorrectResult(
                int number,
                int digit,
                bool result)
            {
                MathHelper.ContainsDigitInNumber(
                        number: number,
                        digit: digit)
                    .Should()
                    .Be(result);
            }
        }
    }
}