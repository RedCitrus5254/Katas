using System;

namespace BankOCR
{
    class Program
    {
        static void Main(
            string[] args)
        {
            var filePath = "test.txt";
            
            var accountNumberManager = CompositionRoot.CreateAccountNumberManager();

            accountNumberManager
                .StartTranslateAccountNumbers(filePath);
        }
    }
}