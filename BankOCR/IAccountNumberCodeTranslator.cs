using System.Collections.Generic;

namespace BankOCR
{
    public interface IAccountNumberCodeTranslator
    {
        List<AccountNumber> Translate(
            List<AccountNumberCode> accountNumberCode);
    }
}