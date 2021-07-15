using System;
using System.Collections.Generic;
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

            foreach (var accountNumber in accountNumbers)
            {
                var message = accountNumber.Number;
                
                if (accountNumber.Number.Contains('?'))
                {
                    message += "ILL";
                    Console.WriteLine(message);
                    Console.WriteLine("---------------------------------");
                    continue;
                }
                
                if (!accountNumberValidator.Validate(
                    accountNumber: accountNumber))
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