using System.Collections.Generic;

namespace BankOCR
{
    public class AccountNumberManager: IAccountNumberManager
    {
        private readonly IReader reader;
        private readonly IAccountNumberCodeTranslator accountNumberCodeTranslator;

        public AccountNumberManager(
        IReader reader,
        IAccountNumberCodeTranslator accountNumberCodeTranslator)
        {
            this.reader = reader;
            this.accountNumberCodeTranslator = accountNumberCodeTranslator;
        }
        public List<AccountNumber> GetAccountNumbers(
            string filePath)
        {
            var accountNumberCodeList = reader
                .GetAccountNumberCodeList(
                    filePath: filePath);

            return accountNumberCodeTranslator.Translate(
                accountNumberCode: accountNumberCodeList);
        }
    }
}