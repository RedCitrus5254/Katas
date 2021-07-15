using System.IO;

namespace BankOCR
{
    using System.Collections.Generic;
    
    public class FileReader: IReader 
    {
        public List<AccountNumberCode> GetAccountNumberCodeList(
            string filePath)
        {
            var accountNumberCodeList = new List<AccountNumberCode>();
            
            using var streamReader = new StreamReader(
                path: filePath);

            while (!streamReader.EndOfStream)
            {
                accountNumberCodeList.Add(
                    item: new AccountNumberCode(
                        firstString: streamReader.ReadLine(),
                        secondString: streamReader.ReadLine(),
                        thirdString: streamReader.ReadLine()));
                
                streamReader.ReadLine();
            }

            return accountNumberCodeList;
        }
    }
}       