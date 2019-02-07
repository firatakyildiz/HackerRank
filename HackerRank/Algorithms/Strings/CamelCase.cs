using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Strings
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/camelcase/problem
    /// Difficulty : Easy
    /// </summary>
    public static class CamelCase
    {
        public static void Solve()
        {
            Console.WriteLine(Console.ReadLine().Count(char.IsUpper) + 1);
        }
    }
}
