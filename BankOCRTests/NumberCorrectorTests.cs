using System.Collections.Generic;
using System.Linq;
using BankOCR.BusinessLogic;
using BankOCR.Infrastructure;
using FluentAssertions;
using Xunit;

namespace BankOCRTests
{
    public class NumberCorrectorTests
    {
        public static IEnumerable<object[]> Numbers =>
            GenerateTestData()
                .Select(
                    selector: item =>
                        new object[] { item });
        
        [Theory]
        [MemberData(memberName: nameof(Numbers))]
        public void ShouldCorrectNumber(
            TestDataInput testDataInput)
        {
            var numberConverter = new NumberConverter();
            var sut = new NumberCorrector(
                numberConverter: numberConverter);

            var correctedNumber = sut.CorrectNumber(
                uncorrectNumber: testDataInput.AccountNumber,
                accountNumberCode: testDataInput.AccountNumberCode);

            correctedNumber
                .Should()
                .BeEquivalentTo(testDataInput.CorrectedAccountNumber);
        }
        
        private static IEnumerable<TestDataInput> GenerateTestData()
        {
            yield return new TestDataInput(
                new AccountNumber(
                    number: "123456789"),
                new AccountNumberCode(
                    firstString:  " _  _  _  _  _  _  _  _  _ ",
                    secondString: "  |  |  |  |  |  |  |  |  |",
                    thirdString:  "  |  |  |  |  |  |  |  |  |"),
                correctedAccountNumber: new AccountNumber(
                    number: "777777177"));
            yield return new TestDataInput(
                new AccountNumber(
                    number: "111111111"),
                new AccountNumberCode(
                    firstString:  "                           ",
                    secondString: "  |  |  |  |  |  |  |  |  |",
                    thirdString:  "  |  |  |  |  |  |  |  |  |"),
                correctedAccountNumber: new AccountNumber(
                    number: "711111111"));
            yield return new TestDataInput(
                new AccountNumber(
                    number: "888888888"),
                new AccountNumberCode(
                    firstString: " _  _  _  _  _  _  _  _  _ ",
                   secondString: "|_||_||_||_||_||_||_||_||_|",
                    thirdString: "|_||_||_||_||_||_||_||_||_|"
                ),
                correctedAccountNumber: new AccountNumber(
                    number: "888888888"));
        }
        
        
        public class TestDataInput
        {
            public TestDataInput(
                AccountNumber accountNumber,
                AccountNumberCode accountNumberCode,
                AccountNumber correctedAccountNumber)
            {
                this.AccountNumber = accountNumber;
                this.AccountNumberCode = accountNumberCode;
                this.CorrectedAccountNumber = correctedAccountNumber;
            }
            
            public AccountNumber AccountNumber { get; }
            
            public AccountNumberCode AccountNumberCode { get; }
            
            public AccountNumber CorrectedAccountNumber { get; }
        }
    }
}