using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/strange-advertising/problem
    /// Difficulty : Easy
    /// </summary>
    public static class ViralAdvertising
    {
        public static void Solve()
        {
            var input = int.Parse(Console.ReadLine());
            var total = 0;
            var seen = 5;
            for (int i = 0; i < input; i++)
            {
                var likes = seen / 2;
                seen = likes * 3;
                total += likes;
            }

            Console.WriteLine(total);
        }
    }
}
