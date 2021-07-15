namespace BankOCR.BusinessLogic.Interfaces
{
    public interface IAccountNumberValidator
    {
        bool Validate(
            AccountNumber accountNumber);
    }
}