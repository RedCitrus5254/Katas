namespace BankOCR
{
    using System.Collections.Generic;
    
    public interface IReader
    {
        List<int> GetAccountNumberList(
            string filePath);
    }
}