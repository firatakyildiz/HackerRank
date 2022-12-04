using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.ProjectEuler
{
    /// <summary>
    /// Link : https://www.hackerrank.com/contests/projecteuler/challenges/euler001/problem
    /// Difficulty : Easy
    /// Solution : Checking each number below N for divisibility with 3 ot 5 exceeds time limits. But fortunately we can 
    /// use mathematical formula for sum of arithmetic sequence formula to compute the total sum in constant time. 
    /// We compute the sum of multiples of 3 and 5. Since this sum would include each multiple of 15 twice, we calculate
    /// it and subtract that from the total sum.
    /// </summary>
    public static class _1
    {
        public static void Solve()
        { 
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfTestCases; i++)
            {
                var input = Convert.ToInt32(Console.ReadLine());
                
                // question asks for the sum up to but not including input number
                input -= 1;

                var limitFor3 = input / 3;
                var limitFor5 = input / 5;
                var limitFor15 = input / 15;
                
                var sumFor3 = 3 * CalculateSumOfSeries(limitFor3);
                var sumFor5 = 5 * CalculateSumOfSeries(limitFor5);
                var sumFor15 = 15 * CalculateSumOfSeries(limitFor15);
                
                Console.WriteLine(sumFor3 + sumFor5 - sumFor15);
            }
        }

        private static long CalculateSumOfSeries(int n)
        {
            return ((long)n * (n + 1)) / 2;
        }
    }
}
