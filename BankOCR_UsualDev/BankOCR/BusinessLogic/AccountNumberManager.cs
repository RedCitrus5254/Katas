using System;
using BankOCR.BusinessLogic.Interfaces;

namespace BankOCR.BusinessLogic
{
    public class AccountNumberManager: IAccountNumberManager
    {
        private readonly IReader reader;
        private readonly IAccountNumberCodeTranslator accountNumberCodeTranslator;
        private readonly IAccountNumberValidator accountNumberValidator;

        public AccountNumberManager(
        IReader reader,
        IAccountNumberCodeTranslator accountNumberCodeTranslator,
        IAccountNumberValidator accountNumberValidator)
        {
            this.reader = reader;
            this.accountNumberCodeTranslator = accountNumberCodeTranslator;
            this.accountNumberValidator = accountNumberValidator;
        }
        public void StartTranslateAccountNumbers(
            string filePath)
        {
            var accountNumberCodeList = reader
                .GetAccountNumberCodeList(
                    filePath: filePath);

            var accountNumbers = accountNumberCodeTranslator.Translate(
                accountNumberCode: accountNumberCodeList);

            for(var i=0; i < accountNumbers.Count; i++)
            {
                var message = accountNumbers[i].Number;
                
                if (accountNumbers[i].Number.Contains('?'))
                {
                    message += "ILL";
                    Console.WriteLine(message);
                    Console.WriteLine("---------------------------------");
                    continue;
                }
                
                if (!accountNumberValidator.Validate(
                    accountNumber: accountNumbers[i]))
                {
                    message += "ERR";
                    Console.WriteLine(message);
                    Console.WriteLine("---------------------------------");
                    continue;
                    
                }
                
                Console.WriteLine(message);
                Console.WriteLine("---------------------------------");
            }
        }
        
    }
}