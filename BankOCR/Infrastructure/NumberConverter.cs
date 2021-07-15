using System.Collections.Generic;
using BankOCR.BusinessLogic;
using BankOCR.BusinessLogic.Interfaces;

namespace BankOCR.Infrastructure
{
    public class NumberConverter: INumberConverter
    {
        private Dictionary<string, int> numberDictionary;

        public NumberConverter()
        {
            numberDictionary = new Dictionary<string, int>
            {
                {
                    " _ " +
                    "| |" +
                    "|_|",
                     0
                },
                {
                    "   " +
                    "  |" +
                    "  |",
                    1
                },
                {
                    " _ " +
                    " _|" +
                    "|_ ",
                    2
                },
                {
                    " _ " +
                    " _|" +
                    " _|",
                    3
                },
                {
                    "   " +
                    "|_|" +
                    "  |",
                    4
                },
                {
                    " _ " +
                    "|_ " +
                    " _|",
                    5
                },
                {
                    " _ " +
                    "|_ " +
                    "|_|",
                    6
                },
                {
                    " _ " +
                    "  |" +
                    "  |",
                    7
                },
                {
                    " _ " +
                    "|_|" +
                    "|_|",
                    8
                },
                {
                    " _ " +
                    "|_|" +
                    " _|",
                    9
                },
            };
        }

        public int GetNumber(
            string codeNumber)
        {
            if (!numberDictionary.TryGetValue(codeNumber, out int number))
            {
                throw new IllegibleNumberException(
                    accountNumberCode: new AccountNumberCode(
                        firstString: codeNumber.Substring(0, 3),
                        secondString: codeNumber.Substring(3, 3),
                        thirdString: codeNumber.Substring(6, 3)));
            }
            return number;
        }
    }
}