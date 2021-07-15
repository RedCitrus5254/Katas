using System.Collections.Generic;
using BankOCR.Infrastructure;

namespace BankOCR.BusinessLogic.Interfaces
{
    public interface IReader
    {
        List<AccountNumberCode> GetAccountNumberCodeList(
            string filePath);
    }
}