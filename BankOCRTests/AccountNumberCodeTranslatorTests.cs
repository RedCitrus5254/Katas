using System.Collections.Generic;
using BankOCR.BusinessLogic;
using BankOCR.Infrastructure;
using FluentAssertions;
using Xunit;

namespace BankOCRTests
{
    public class AccountNumberCodeTranslatorTests
    {
        [Fact]
        public void ShouldTranslateNumbers()
        {
            var numberCodes = GenerateTestData();
            
            var expected = new List<AccountNumber>();
            var accountNumberCodes = new List<AccountNumberCode>();

            foreach (var numberCode in numberCodes)
            {
                expected.Add(numberCode.AccountNumber);
                accountNumberCodes.Add(numberCode.AccountNumberCode);
            }
            
            var sut = new AccountNumberCodeTranslator(
                new NumberConverter());
            
            sut
                .Translate(accountNumberCodes: accountNumberCodes)
                .Should()
                .BeEquivalentTo(
                    expectation: expected);
        }

        private static IEnumerable<TestDataInput> GenerateTestData()
        {
            yield return new TestDataInput(
                new AccountNumber(
                    number: "123456789"),
                new AccountNumberCode(
                    firstString:  "    _  _     _  _  _  _  _ ",
                    secondString: "  | _| _||_||_ |_   ||_||_|",
                    thirdString:  "  ||_  _|  | _||_|  ||_| _|"));
            yield return new TestDataInput(
                new AccountNumber(
                    number: "111111111"),
                new AccountNumberCode(
                    firstString:  "                           ",
                    secondString: "  |  |  |  |  |  |  |  |  |",
                    thirdString:  "  |  |  |  |  |  |  |  |  |"));
        }

        public class TestDataInput
        {
            public TestDataInput(
                AccountNumber accountNumber,
                AccountNumberCode accountNumberCode)
            {
                this.AccountNumber = accountNumber;
                this.AccountNumberCode = accountNumberCode;
            }
            
            public AccountNumber AccountNumber { get; }
            
            public AccountNumberCode AccountNumberCode { get; }
        }
        
    }
}