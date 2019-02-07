using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/between-two-sets/problem
    /// Difficulty : Easy
    /// </summary>
    public static class BetweenTwoSets
    {
        public static void Solve()
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nm[0]);
            int m = Convert.ToInt32(nm[1]);
            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
            int[] b = Array.ConvertAll(Console.ReadLine().Split(' '), bTemp => Convert.ToInt32(bTemp));
            int total = getTotalX(a, b);
            Console.WriteLine(total);
        }

        private static int getTotalX(int[] firstArr, int[] secondArr)
        {
            // brute force, since constraints are too low
            var minimum = firstArr.Max();
            var maximum = secondArr.Min();
            var count = 0;
            for (var candidate = minimum; candidate <= maximum; candidate++)
            {
                var skipCandidate = false;
                for (int i = 0; i < firstArr.Length; i++)
                {
                    if (candidate % firstArr[i] != 0)
                    {
                        skipCandidate = true;
                        break;
                    }
                }
                if (skipCandidate)
                    continue;
                skipCandidate = false;
                for (int i = 0; i < secondArr.Length; i++)
                {
                    if (secondArr[i] % candidate != 0)
                    {
                        skipCandidate = true;
                        break;
                    }
                }
                if (!skipCandidate)
                    count++;
            }
            return count;
        }
    }
}
