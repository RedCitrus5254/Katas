using FizzBuzz_TDD_WithoutMouse;
using FluentAssertions;
using Xunit;

namespace FizzBuzz_TDD_WithoutMouseTests
{
    public class MathHelperTests
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
}