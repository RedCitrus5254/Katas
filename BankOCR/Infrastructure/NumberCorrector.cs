using BankOCR.BusinessLogic;
using BankOCR.BusinessLogic.Interfaces;

namespace BankOCR.Infrastructure
{
    public class NumberCorrector: INumberCorrector
    {
        private readonly INumberConverter numberConverter;

        public NumberCorrector(
            INumberConverter numberConverter)
        {
            this.numberConverter = numberConverter;
        }
        public AccountNumber CorrectNumber(
            AccountNumber uncorrectNumber,
            AccountNumberCode accountNumberCode)
        {
            if (uncorrectNumber.Number.Replace("?", string.Empty).Length < uncorrectNumber.Number.Length - 1)
            {
                return uncorrectNumber;
            }
            if (uncorrectNumber.Number.Contains("?"))
            {
                return CorrectNumberWithUncorrectSymbol(
                    uncorrectNumber: uncorrectNumber,
                    accountNumberCode: accountNumberCode);
            }

            return CorrectInvalidNumber(
                uncorrectNumber: uncorrectNumber,
                accountNumberCode: accountNumberCode);
        }

        private AccountNumber CorrectNumberWithUncorrectSymbol(
            AccountNumber uncorrectNumber,
            AccountNumberCode accountNumberCode)
        {
            var position = uncorrectNumber.Number.IndexOf('?');
        }

        private AccountNumber CorrectInvalidNumber(
            AccountNumber uncorrectNumber,
            AccountNumberCode accountNumberCode)
        {
            
            
            
        }

        private AccountNumberCode TryToChangeSymbol(
            AccountNumberCode uncorrectAccountNumberCode)
        {
            var changedAccountNumberCodeString = uncorrectAccountNumberCode.FirstString +
                                           uncorrectAccountNumberCode.SecondString +
                                           uncorrectAccountNumberCode.ThirdString;

            for (var i = 0; i < changedAccountNumberCodeString.Length; i++)
            {
                var newCode = ChangeSymbolInStrToEmpty(
                    changedAccountNumberCodeString,
                    i);

                try
                {
                    var newNum = numberConverter.GetNumber(newCode);
                    return new AccountNumberCode(
                        newCode.Substring(0, 3),
                        newCode.Substring(3, 3),
                        newCode.Substring(6, 3));
                }
                catch (IllegibleNumberException)
                {
                    continue;
                }
                



            }
        }

        private string ChangeSymbolInStrToEmpty(
            string code,
            int position)
        {
            var charArr = code.ToCharArray();

            charArr[position] = ' ';

            return charArr.ToString();
        }
        
    }
}