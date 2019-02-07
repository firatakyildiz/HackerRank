using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Strings
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/mars-exploration/problem
    /// Difficulty : Easy
    /// </summary>
    public static class MarsExploration
    {
        public static void Solve()
        {
            var input = Console.ReadLine();
            var count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if ((i % 3 == 1 && input[i] != 'O') || (i % 3 != 1 && input[i] != 'S'))
                    count++;
            }
            Console.WriteLine(count);
        }
    }
}
