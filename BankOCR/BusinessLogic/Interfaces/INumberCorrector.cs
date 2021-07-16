using BankOCR.Infrastructure;

namespace BankOCR.BusinessLogic.Interfaces
{
    public interface INumberCorrector
    {
        AccountNumber CorrectNumber(
            AccountNumber uncorrectNumber,
            AccountNumberCode accountNumberCode);
    }
}