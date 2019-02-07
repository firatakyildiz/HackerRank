using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/the-hurdle-race/problem
    /// Difficulty : Easy
    /// </summary>
    public static class HurdleRace
    {
        public static void Solve()
        {
            var jumpHeight = int.Parse(Console.ReadLine().Split()[1]);
            var maxHeight = Array.ConvertAll(Console.ReadLine().Split(), int.Parse).Max();
            Console.WriteLine(maxHeight - jumpHeight >= 0 ? maxHeight - jumpHeight : 0);
        }
    }
}
