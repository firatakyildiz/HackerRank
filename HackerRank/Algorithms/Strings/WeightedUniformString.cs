using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Strings
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/weighted-uniform-string/problem
    /// Difficulty : Easy
    /// </summary>
    public static class WeightedUniformString
    {
        public static void Solve()
        {
            var input = Console.ReadLine();
            var numberOfQueries = int.Parse(Console.ReadLine());
            var queries = new int[numberOfQueries];
            for (int i = 0; i < numberOfQueries; i++)
            {
                queries[i] = int.Parse(Console.ReadLine());
            }

            foreach (var answer in IsPossible(input, queries))
            {
                Console.WriteLine(answer ? "Yes" : "No");
            }
        }

        private static bool[] IsPossible(string input, int[] queries)
        {
            var list = new HashSet<int>();
            var previousValue = 0;
            var previousChar = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var value = input[i] - 'a' + 1;
                list.Add(value);

                if (input[i] == previousChar)
                {
                    previousValue += value;
                    list.Add(previousValue);
                }
                else
                {
                    previousValue = value;
                }
                previousChar = input[i];
            }
            var returnArr = new bool[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                returnArr[i] = list.Contains(queries[i]);
            }
            return returnArr;
        }
    }
}
