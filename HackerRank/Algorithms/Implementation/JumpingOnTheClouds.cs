using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/jumping-on-the-clouds/problem
    /// Difficulty : Easy
    /// </summary>
    public static class JumpingOnTheClouds
    {
        public static void Solve()
        {
            var len = Console.ReadLine();
            var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var count = 0;
            var index = 0;
            while (true)
            {
                count++;
                if (index + 3 >= arr.Length)
                    break;
                if (arr[index + 2] == 0)
                    index += 2;
                else
                    index++;
            }

            Console.WriteLine(count);
        }
    }
}
