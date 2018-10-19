using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/non-divisible-subset
    /// Difficulty : Medium
    /// </summary>
    public static class NonDivisibleSubset
    {
        public static void Solve() {
            var temp = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Console.WriteLine(getLargestPossibleSubsetSize(temp[0],temp[1],arr));
        }

        /// <summary>
        /// Solution Explanation : We organize each integer into groups in according to their remainder
        ///     when divided by divisor. Each group has a counterpart which will allow the sum of
        ///     two integers from those two groups divisible by divisor. We take the group with more
        ///     elements, include them all in our resulting subset and discard the other group.
        ///     There are two exceptional groups however, one is remainder 0. We include only one item from
        ///     this group. The other exceptional group appears if the divisor is an even integer.
        ///     In this case, we include only one item from this group also.
        /// </summary>
        /// <param name="len">Length of the original array</param>
        /// <param name="divisor">Dividing number</param>
        /// <param name="arr">Original array</param>
        /// <returns></returns>
        private static int getLargestPossibleSubsetSize(int len, int divisor, int[] arr)
        {
            var count = 0;
            // this will keep the counts of numbers,grouping them
            // to their remainders when divided by divisor
            var remainders = new int[divisor];
            for (int i = 0; i < len; i++)
            {
                var remainder = arr[i] % divisor;
                remainders[remainder]++;
            }
            // now we add numbers that do not contradict our goal
            for (int i = 1; i < (divisor + 1) / 2; i++)
            {
                if (remainders[i] > remainders[divisor - i]) {
                    count += remainders[i];
                }
                else
                {
                    count += remainders[divisor - i];
                }
            }
            if (divisor % 2 == 0 && remainders[divisor / 2] > 0)
                count++;
            if (remainders[0] > 0)
                count++;
            return count;
        }
    }
}
