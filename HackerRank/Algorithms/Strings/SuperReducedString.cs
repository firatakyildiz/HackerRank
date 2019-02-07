using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Strings
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/reduced-string/problem
    /// Difficulty : Easy
    /// </summary>
    public static class SuperReducedString
    {
        public static void Solve()
        {
            var input = Console.ReadLine();
            if (input == null || input.Length < 2)
            {
                Console.WriteLine(input);
                return;
            }
            var list = new List<char>();
            var listIndex = -1;
            for (var inputIndex = 0; inputIndex < input.Length; inputIndex++)
            {
                if (listIndex == -1 || list[listIndex] != input[inputIndex])
                {
                    list.Add(input[inputIndex]);
                    listIndex++;
                }
                else
                {
                    list.RemoveAt(listIndex--);
                }
            }

            Console.WriteLine(list.Any() ? string.Join("", list) : "Empty String");
        }
    }
}
