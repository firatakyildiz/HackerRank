using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/divisible-sum-pairs/problem
    /// Difficulty : Easy
    /// </summary>
    public static class DivisibleSumPairs
    {
        public static void Solve()
        {
            string[] nk = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nk[0]);
            int k = Convert.ToInt32(nk[1]);
            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
            int result = divisibleSumPairs(n, k, ar);
            Console.WriteLine(result);
        }

        private static int divisibleSumPairs(int len, int sum, int[] arr)
        {
            var count = 0;
            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if ((arr[i] + arr[j]) % sum == 0)
                        count++;
                }
            }
            return count;
        }
    }
}
