using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.ProjectEuler
{
    public static class _3
    {
        /// <summary>
        /// Link : https://www.hackerrank.com/contests/projecteuler/challenges/euler003/problem
        /// Difficulty : Easy
        /// Solution : Divide number with factors repeatedly, the largest divisor is the largest prime
        /// </summary>
        public static void Solve()
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfTestCases; i++)
            {
                var inputNumber = Convert.ToInt64((Console.ReadLine()));
                var limit = Math.Sqrt(inputNumber);
                var currentNumber = inputNumber;
                var largestPrimeFactor = 0L;
                var currentPrimeFactor = 2L;

                while (currentPrimeFactor <= currentNumber)
                {
                    if (currentNumber % currentPrimeFactor == 0)
                    {
                        largestPrimeFactor = currentPrimeFactor;
                        currentNumber /= currentPrimeFactor;
                    }
                    else
                    {
                        // if there are no prime factors found yet and we reached the sqrt of input number
                        // that means the number is prime
                        if (currentPrimeFactor > limit && largestPrimeFactor == 0)
                            break;
                        if (currentPrimeFactor % 2 == 0)
                            currentPrimeFactor += 1;
                        else
                            currentPrimeFactor += 2;
                    }
                }

                // if there is no prime factor found, that means largest prime factor is number itself
                if (largestPrimeFactor == 0)
                    largestPrimeFactor = inputNumber;

                Console.WriteLine(largestPrimeFactor);
            }
        }
    }
}
