namespace BankOCR
{
    public class CompositionRoot
    {
        public static AccountNumberManager CreateAccountNumberManager()
        {
            return new AccountNumberManager(
                new FileReader(),
                new AccountNumberCodeTranslator());
        }
    }
}