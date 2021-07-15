using System.Collections.Generic;
using BankOCR.BusinessLogic;
using BankOCR.BusinessLogic.Interfaces;

namespace BankOCR.Infrastructure
{
    public class AccountNumberCodeTranslator: IAccountNumberCodeTranslator
    {
        private readonly INumberConverter numberConverter;

        public AccountNumberCodeTranslator(
            INumberConverter numberConverter)
        {
            this.numberConverter = numberConverter;
        }
        
        public List<AccountNumber> Translate(
            List<AccountNumberCode> accountNumberCodes)
        {
            var accountNumberList = new List<AccountNumber>();
            
            foreach (var accountNumberCode in accountNumberCodes)
            {
                var accountNumber = TranslateAccountNumber(
                    accountNumberCode: accountNumberCode);
                
                accountNumberList
                    .Add(
                        item: new AccountNumber(
                            number: accountNumber));
            }

            return accountNumberList;
        }

        private string TranslateAccountNumber(
            AccountNumberCode accountNumberCode)
        {
            var accountNumber = "";
                
            var offset = 0;
            for (var i = 0; i < 9; i++)
            {
                accountNumber += TranslateSymbol(
                    code: accountNumberCode.FirstString.Substring(offset, 3)
                          + accountNumberCode.SecondString.Substring(offset, 3)
                          + accountNumberCode.ThirdString.Substring(offset, 3));

                offset += 3;
            }

            return accountNumber;
        }

        private char TranslateSymbol(
            string code)
        {
            try
            {
                return char.Parse(
                    numberConverter
                    .GetNumber(
                        codeNumber: code)
                    .ToString());
            }
            catch (IllegibleNumberException)
            {
                return '?';
            }
        }
    }
}