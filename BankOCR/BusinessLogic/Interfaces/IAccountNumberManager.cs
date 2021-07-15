using System.Collections.Generic;

namespace BankOCR.BusinessLogic.Interfaces
{
    public interface IAccountNumberManager
    {
        void StartTranslateAccountNumbers(
            string filePath);
    }
}