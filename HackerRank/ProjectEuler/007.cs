using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.ProjectEuler
{
    /// <summary>
    /// Link : https://www.hackerrank.com/contests/projecteuler/challenges/euler007/problem
    /// Difficulty : Easy
    /// Solution : Simple calculation
    /// </summary>
    public static class _7
    {
        private static List<int> primeNumbers = new List<int>() { 2, 3 };
        public static void Solve()
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < numberOfTestCases; i++)
            {
                var number = Convert.ToInt32(Console.ReadLine());
                var primeValue = GetNthPrimeNumber(number);
                Console.WriteLine(primeValue);
            }
        }

        private static void FindNextPrimeNumbers(int number)
        {
            var numberOfKnownPrimes = primeNumbers.Count;
            var value = primeNumbers[numberOfKnownPrimes - 1];

            while (numberOfKnownPrimes < number)
            {
                value += 2;
                if (IsPrime(value))
                {
                    primeNumbers.Add(value);
                    numberOfKnownPrimes++;
                }
            }
        }

        private static int GetNthPrimeNumber(int number)
        {
            if (primeNumbers.Count < number)
                FindNextPrimeNumbers(number);
            return primeNumbers[number - 1];
        }

        // since we keep all primes in memory, we can determine if a new number is prime or not
        // by just trying to divide the new number with existing primes
        private static bool IsPrime(int number)
        {
            foreach (var item in primeNumbers)
            {
                if (number % item == 0)
                    return false;
            }
            return true;
        }
    }
}
