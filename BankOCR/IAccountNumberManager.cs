using System.Collections.Generic;

namespace BankOCR
{
    public interface IAccountNumberManager
    {
        List<AccountNumber> GetAccountNumbers(
            string filePath);
    }
}