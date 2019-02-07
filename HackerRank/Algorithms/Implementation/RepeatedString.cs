using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/repeated-string/problem
    /// Difficulty : Easy
    /// </summary>
    public static class RepeatedString
    {
        public static void Solve()
        {
            var input = Console.ReadLine();
            var size = long.Parse(Console.ReadLine());

            var count = (size / input.Length) * input.Count(x => x == 'a')
                        + input.Substring(0, (int)(size % input.Length)).Count(x => x == 'a');
            Console.WriteLine(count);
        }
    }
}
