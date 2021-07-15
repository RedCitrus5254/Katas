using System.Collections.Generic;
using BankOCR.Infrastructure;

namespace BankOCR.BusinessLogic.Interfaces
{
    public interface IAccountNumberCodeTranslator
    {
        List<AccountNumber> Translate(
            List<AccountNumberCode> accountNumberCode);
    }
}