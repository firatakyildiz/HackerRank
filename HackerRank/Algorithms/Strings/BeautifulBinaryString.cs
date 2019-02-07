using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Strings
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/beautiful-binary-string/problem
    /// Difficulty : Easy
    /// </summary>
    public static class BeautifulBinaryString
    {
        public static void Solve()
        {
            var len = Console.ReadLine();
            var input = Console.ReadLine();
            var index = 0;
            var count = 0;
            while (index < input.Length)
            {
                index = input.IndexOf("010", index);
                if (index == -1)
                    break;
                count++;
                index += 3;
            }
            Console.WriteLine(count);
        }
    }
}
