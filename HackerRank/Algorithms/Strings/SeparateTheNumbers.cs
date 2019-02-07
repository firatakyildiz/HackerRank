using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Strings
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/separate-the-numbers/problem
    /// Difficulty : Easy
    /// </summary>
    public static class SeparateTheNumbers
    {
        public static void Solve()
        {
            var numberOfQueries = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfQueries; i++)
            {
                var result = GetBeautifulStart(Console.ReadLine());
                Console.WriteLine(result == -1 ? "NO" : "YES " + result);
            }
        }

        private static long GetBeautifulStart(string input)
        {
            if (input.StartsWith("0"))
                return -1;
            for (int digits = 1; digits <= input.Length / 2; digits++)
            {
                var startingNumber = long.Parse(input.Substring(0, digits));
                var nextNumber = startingNumber + 1;
                var index = digits;
                while (index != input.Length)
                {
                    var nextNumberString = nextNumber.ToString();
                    if (index + nextNumberString.Length > input.Length 
                        || input.Substring(index, nextNumberString.Length) != nextNumberString)
                        break;
                    nextNumber++;
                    index += nextNumberString.Length;
                }

                if (index == input.Length)
                    return startingNumber;
            }
            return -1;
        }
    }
}
