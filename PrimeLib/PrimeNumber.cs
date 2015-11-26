using System;
using System.Collections.Generic;

namespace PrimeLib
{
    public interface IPrimeNumber
    {
        List<long> GetFirstNPrimeNumbers(int count);
        long GetNextPrimeNumber(long input);
        bool IsPrimeNumber(long num);
    }

    public class PrimeNumber : IPrimeNumber
    {
        public List<long> GetFirstNPrimeNumbers(int count)
        {
            if (count < 2) throw new Exception("Invalid input");
            long primeNumber = 2;
            var primeNumbers = new List<long>(count) { primeNumber };
            while (primeNumbers.Count < count)
            {
                primeNumber = GetNextPrimeNumber(primeNumber);
                primeNumbers.Add(primeNumber);
            }
            return primeNumbers;
        }

        public long GetNextPrimeNumber(long input)
        {
            var isPrimeNumber = false;
            while (!isPrimeNumber)
            {
                input++;
                isPrimeNumber = IsPrimeNumber(input);
            }
            return input;
        }

        public bool IsPrimeNumber(long num)
        {
            var isPrimeNumber = true;
            var factor = num / 2;
            for (var i = 2; i <= factor; i++)
            {
                isPrimeNumber = (num % i != 0);
                if (!isPrimeNumber) break;
            }
            return isPrimeNumber;
        }
    }
}
