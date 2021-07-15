namespace BankOCR.BusinessLogic
{
    public class AccountNumber
    {
        public AccountNumber(
            string number)
        {
            Number = number;
        }
        
        public string Number { get; }
    }
}