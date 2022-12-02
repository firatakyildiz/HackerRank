using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.ProjectEuler
{
    /// <summary>
    /// Link : https://www.hackerrank.com/contests/projecteuler/challenges/euler002/problem
    /// Difficulty : Easy
    /// Solution : Bruteforce falls within time constaints, so we just compute required sums.
    /// </summary>
    public static class _2
    {
        public static void Solve()
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < numberOfTestCases; i++)
            {
                var limit = Convert.ToInt64(Console.ReadLine());
                var first = 1L;
                var second = 2L;
                var total = 0L;

                while (second < limit)
                {
                    if (second % 2 == 0)
                        total += second;

                    second += first;
                    first = second - first;
                }

                Console.WriteLine(total);
            }
        }
    }
}
