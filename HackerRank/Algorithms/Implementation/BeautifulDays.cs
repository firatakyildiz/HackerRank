using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/beautiful-days-at-the-movies/problem
    /// Difficulty : Easy
    /// </summary>
    public static class BeautifulDays
    {
        public static void Solve()
        {
            var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var count = 0;
            for (int i = input[0]; i <= input[1]; i++)
            {
                if (Math.Abs(i - int.Parse(new string(i.ToString().Reverse().ToArray()))) % input[2] == 0)
                    count++;
            }

            Console.WriteLine(count);
        }
    }
}
