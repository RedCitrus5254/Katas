using BankOCR.BusinessLogic;
using BankOCR.BusinessLogic.Interfaces;
using BankOCR.Infrastructure;

namespace BankOCR
{
    public class CompositionRoot
    {
        public static IAccountNumberManager CreateAccountNumberManager()
        {
            return new AccountNumberManager(
                new FileReader(),
                new AccountNumberCodeTranslator(
                    new NumberConverter()),
                new AccountNumberValidator());
        }
    }
}