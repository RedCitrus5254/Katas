using BankOCR.BusinessLogic;
using BankOCR.BusinessLogic.Interfaces;
using BankOCR.Infrastructure;

namespace BankOCR
{
    public class CompositionRoot
    {
        public static IAccountNumberManager CreateAccountNumberManager()
        {
            var numberConverter = new NumberConverter();
            
            return new AccountNumberManager(
                reader: new FileReader(),
                accountNumberCodeTranslator: new AccountNumberCodeTranslator(
                    numberConverter: numberConverter),
                accountNumberValidator: new AccountNumberValidator());
        }
    }
}