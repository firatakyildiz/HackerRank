using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Strings
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/string-construction/problem
    /// Difficulty : Easy
    /// </summary>
    public static class StringConstruction
    {
        public static void Solve()
        {
            var len = int.Parse(Console.ReadLine());
            for (int i = 0; i < len; i++)
            {
                var input = Console.ReadLine();
                Console.WriteLine(GetCost(input));
            }
        }

        private static int GetCost(string input)
        {
            var set = new HashSet<char>();
            foreach (var character in input)
            {
                set.Add(character);
            }
            return set.Count;
        }
    }
}
