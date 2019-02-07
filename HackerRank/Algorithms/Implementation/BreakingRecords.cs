using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/breaking-best-and-worst-records/problem
    /// Difficulty : Easy
    /// </summary>
    public static class BreakingRecords
    {
        public static void Solve()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp));
            int[] result = breakingRecords(scores);
            Console.WriteLine(string.Join(" ", result));
        }

        private static int[] breakingRecords(int[] scores)
        {
            var best = scores[0];
            var worst = scores[0];
            var countBest = 0;
            var countWorst = 0;
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] > best)
                {
                    countBest++;
                    best = scores[i];
                }
                if (scores[i] < worst)
                {
                    countWorst++;
                    worst = scores[i];
                }
            }
            return new []{countBest, countWorst};
        }
    }
}
