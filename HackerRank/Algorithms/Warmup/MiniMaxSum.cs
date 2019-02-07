using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Warmup
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/mini-max-sum/problem
    /// Difficulty : Easy
    /// </summary>
    public static class MiniMaxSum
    {
        public static void Solve()
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            miniMaxSum(arr);
        }

        private static void miniMaxSum(int[] arr)
        {
            var min = int.MaxValue;
            var max = int.MinValue;
            var total = 0L;
            foreach (var i in arr)
            {
                if (i > max)
                    max = i;
                if (i < min)
                    min = i;
                total += i;
            }
            Console.WriteLine((total - max) + " " + (total - min));
        }
    }
}
