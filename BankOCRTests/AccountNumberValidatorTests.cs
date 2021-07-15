using System.Collections.Generic;
using System.Linq;
using BankOCR.BusinessLogic;
using BankOCR.Infrastructure;
using FluentAssertions;
using Xunit;

namespace BankOCRTests
{
    public class AccountNumberValidatorTests
    {
        public static IEnumerable<object[]> ValidationResults =>
            GenerateTestData()
                .Select(
                    selector: item =>
                        new object[] { item });
        
        [Theory]
        [MemberData(memberName: nameof(ValidationResults))]
        public void ShouldCorrectlyValidate(
            ValidationData validationData)
        {
            var sut = new AccountNumberValidator();

            sut
                .Validate(
                    accountNumber: validationData
                        .Number)
                .Should()
                .Be(
                   expected: validationData
                       .IsValid);
        }

        public static IEnumerable<ValidationData> GenerateTestData()
        {
            yield return new ValidationData(
                number: new AccountNumber("111111111"),
                isValid: false);
            yield return new ValidationData(
                number: new AccountNumber("123456789"),
                isValid: true);
            yield return new ValidationData(
                number: new AccountNumber("000000051"),
                isValid: true);
            yield return new ValidationData(
                number: new AccountNumber("777777777"),
                isValid: false);
            yield return new ValidationData(
                number: new AccountNumber("200000000"),
                isValid: false);
            yield return new ValidationData(
                number: new AccountNumber("000000000"),
                isValid: true);
        }

        public class ValidationData
        {
            public ValidationData(
                AccountNumber number,
                bool isValid)
            {
                this.Number = number;
                this.IsValid = isValid;
            }
            
            public AccountNumber Number { get; }
            
            public bool IsValid { get; }
        }
    }
}