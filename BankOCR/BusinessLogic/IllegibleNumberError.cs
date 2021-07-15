using System;
using BankOCR.Infrastructure;

namespace BankOCR.BusinessLogic
{
    public class IllegibleNumberException: Exception
    {
        public IllegibleNumberException(
            AccountNumberCode accountNumberCode)
        {
            AccountNumberCode = accountNumberCode;
        }
        public AccountNumberCode AccountNumberCode { get; }
    }
}