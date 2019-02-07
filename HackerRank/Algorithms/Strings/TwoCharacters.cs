using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Strings
{
    public static class TwoCharacters
    {
        public static void Solve()
        {
            var len = Console.ReadLine();
            var input = Console.ReadLine().ToCharArray();
            const int alphabetSize = 26;
            const char startCharacter = 'a';
            var letterCounts = new int[alphabetSize];
            var maxLength = 0;
            // find how many times each letter occurs in input
            for (int i = 0; i < input.Length; i++)
            {
                letterCounts[input[i] - 'a']++;
            }

            // for each combination, calculate the result
            for (int i = 0; i < alphabetSize; i++)
            {
                if (letterCounts[i] == 0)
                    continue;
                for (int j = i + 1; j < alphabetSize; j++)
                {
                    if (letterCounts[j] == 0)
                        continue;
                    // a little optimization, the letter counts must at most differ by 1,
                    // or they can not be alternating
                    if (Math.Abs(letterCounts[i] - letterCounts[j]) > 1)
                        continue;
                    var outputString = input.Where(x => x == startCharacter + i || x == startCharacter + j).ToArray();
                    if (IsAlternating(outputString) && outputString.Length > maxLength)
                        maxLength = outputString.Length;
                }
            }

            Console.WriteLine(maxLength);
        }

        private static bool IsAlternating(char[] outputString)
        {
            var firstCharacter = outputString[0];
            var secondCharacter = outputString[1];
            var alternate = true;
            for (int i = 2; i < outputString.Length; i++)
            {
                if (alternate)
                {
                    if (outputString[i] != firstCharacter)
                        return false;
                }
                else
                {
                    if (outputString[i] != secondCharacter)
                        return false;
                }

                alternate = !alternate;
            }

            return true;
        }
    }
}
