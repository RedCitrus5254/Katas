namespace BankOCR.Infrastructure
{
    public class AccountNumberCode
    {
        public AccountNumberCode(
            string firstString,
            string secondString,
            string thirdString)
        {
            FirstString = firstString;
            SecondString = secondString;
            ThirdString = thirdString;
        }
        
        public string FirstString { get; }
        
        public string SecondString { get; }
        
        public string ThirdString { get; }
    }
}