using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Strings
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/hackerrank-in-a-string/problem
    /// Difficulty : Easy
    /// </summary>
    public static class HackerrankInAString
    {
        public static void Solve()
        {
            var numberOfQueries = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfQueries; i++)
            {
                var input = Console.ReadLine();
                Console.WriteLine(IsPossible(input) ? "YES" : "NO");
            }
        }

        private static bool IsPossible(string input)
        {
            var hackerrank = "hackerrank";
            var hackerIndex = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == hackerrank[hackerIndex])
                {
                    hackerIndex++;
                    if (hackerIndex == hackerrank.Length)
                        break;
                }
            }
            return hackerIndex == hackerrank.Length;
        }
    }
}
