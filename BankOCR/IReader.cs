namespace BankOCR
{
    using System.Collections.Generic;
    
    public interface IReader
    {
        List<AccountNumberCode> GetAccountNumberCodeList(
            string filePath);
    }
}