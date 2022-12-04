using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.ProjectEuler
{
    /// <summary>
    /// Link : https://www.hackerrank.com/contests/projecteuler/challenges/euler006/problem
    /// Difficulty : Easy
    /// Solution : Simple calculation
    /// </summary>
    public static class _6
    {
        public static void Solve()
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < numberOfTestCases; i++)
            {
                var number = Convert.ToInt32(Console.ReadLine());
                
                var sumOfSquares = 0L;
                for (var j = 1; j <= number; j++)
                {
                    sumOfSquares += j * j;
                }

                var squareOfTheSum = (long)Math.Pow((number * (number + 1)) / 2, 2);
                
                Console.WriteLine(Math.Abs(sumOfSquares - squareOfTheSum));
            }
        }
    }
}
