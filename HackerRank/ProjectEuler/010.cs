using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.ProjectEuler
{
    /// <summary>
    /// Link : https://www.hackerrank.com/contests/projecteuler/challenges/euler010/problem
    /// Difficulty : Medium
    /// Solution : Finding primes up to a billion takes too much time, even if precomputed naively. So we use Sieve of Eratosthenes
    /// for precomputing, while also saving the totals. Then answer questions with a simple look-up.  
    /// </summary>
    public static class _10
    {
        private static bool[] _sieveOfEratosthenes;
        private static long[] _primeTotals;

        private static void CalculateSieve(int limit)
        {
            var existingSum = 0L;
            _sieveOfEratosthenes = new bool[limit + 1];
            _primeTotals = new long[limit + 1];

            for (var i = 2; i <= limit; i++)
            {
                // this number is prime
                if (!_sieveOfEratosthenes[i])
                {
                    // add the current total
                    existingSum += i;

                    // mark all the multiples of this value as non-prime
                    var index = i * 2;
                    while (index <= limit)
                    {
                        _sieveOfEratosthenes[index] = true;
                        index += i;
                    }
                }

                // save the current total
                _primeTotals[i] = existingSum;
            }
        }

        public static void Solve()
        {
            CalculateSieve((int)Math.Pow(10,6));
            
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < numberOfTestCases; i++)
            {
                var number = Convert.ToInt32(Console.ReadLine());
                var result = _primeTotals[number];
                Console.WriteLine(result);
            }
        }
    }
}
