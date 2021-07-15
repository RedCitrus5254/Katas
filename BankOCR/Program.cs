using System;

namespace BankOCR
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = args[0] ?? "test.txt";
            
            var accountNumberManager = CompositionRoot.CreateAccountNumberManager();

            var accountNumbers = accountNumberManager
                .GetAccountNumbers(filePath);

            foreach (var accountNumber in accountNumbers)
            {
                Console.WriteLine(accountNumber); 
            }
        }
    }
}