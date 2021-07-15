using System;
using BankOCR.BusinessLogic;
using BankOCR.BusinessLogic.Interfaces;

namespace BankOCR.Infrastructure
{
    public class AccountNumberValidator : IAccountNumberValidator
    {
        public bool Validate(
            AccountNumber accountNumber)
        {
            var sum = 0;
            var coefficient = 9;
            foreach (var symbol in accountNumber.Number)
            {
                sum += coefficient * Convert.ToInt32(symbol.ToString());
                coefficient--;
            }

            if (sum % 11 == 0)
            {
                return true;
            }

            return false;
        }
    }
}