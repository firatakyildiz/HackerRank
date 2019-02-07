using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/drawing-book/problem
    /// Difficulty : Easy
    /// </summary>
    public static class DrawingBook
    {
        public static void Solve()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int p = Convert.ToInt32(Console.ReadLine());
            var back = n - p == 1 && n % 2 == 0? 1 : (n - p) / 2;
            int result = Math.Min(p / 2, back);
            Console.WriteLine(result);
        }
    }
}
