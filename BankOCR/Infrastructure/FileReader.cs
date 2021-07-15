using System.Collections.Generic;
using System.IO;
using BankOCR.BusinessLogic.Interfaces;

namespace BankOCR.Infrastructure
{
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