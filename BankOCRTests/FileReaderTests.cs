using System.Collections.Generic;
using BankOCR.Infrastructure;
using FluentAssertions;
namespace BankOCRTests
{
    using Xunit;
    
    public class FileReaderTests
    {
        [Fact]
        public void ReadCorrectSimpleAccountNumberCodeList()
        {
            var expected = new List<AccountNumberCode>()
            {
                new AccountNumberCode(
                    firstString:  " _  _  _  _  _  _  _  _  _ ",
                    secondString: "| || || || || || || || || |",
                    thirdString:  "|_||_||_||_||_||_||_||_||_|"),
                new AccountNumberCode(
                    firstString:  "                           ",
                    secondString: "  |  |  |  |  |  |  |  |  |",
                    thirdString:  "  |  |  |  |  |  |  |  |  |"),
                new AccountNumberCode(
                    firstString:  " _  _  _  _  _  _  _  _  _ ",
                    secondString: " _| _| _| _| _| _| _| _| _|",
                    thirdString:  "|_ |_ |_ |_ |_ |_ |_ |_ |_ "),
                new AccountNumberCode(
                    firstString:  " _  _  _  _  _  _  _  _  _ ",
                    secondString: " _| _| _| _| _| _| _| _| _|",
                    thirdString:  " _| _| _| _| _| _| _| _| _|"),
            };
            var sut = new FileReader();

            var accountNumberCodeList = sut.GetAccountNumberCodeList("../../../TestFiles/SimpleAccountNumberCodeList.txt");

            accountNumberCodeList
                .Should()
                .BeEquivalentTo(
                    expectation: expected);
        }
    }
}