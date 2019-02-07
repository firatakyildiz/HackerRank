using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/counting-valleys/problem
    /// Difficulty : Easy
    /// </summary>
    public static class CountingValleys
    {
        public static void Solve()
        {
            var len = Console.ReadLine();
            var path = Console.ReadLine();
            var elevation = 0;
            var count = 0;
            for (int i = 0; i < path.Length; i++)
            {
                if (elevation == 0 && path[i] == 'D')
                {
                    count++;
                }

                elevation += path[i] == 'U' ? 1 : -1;
            }

            Console.WriteLine(count);
        }
    }
}
