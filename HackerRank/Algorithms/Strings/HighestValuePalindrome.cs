using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HackerRank.Algorithms.Strings
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/richie-rich/problem
    /// Difficulty : Medium
    /// Solution : First, iterate over the string and find the number of characters that needs to
    /// be changed for it to be a palindrome. If the number is less than available changes,
    /// it cannot be made a palindrome. Then using those two numbers, calculate the additional(extra)
    /// number of characters that we can change. Starting from the beginning, use those extra characters
    /// to increase the value of the string. See inline comments for more details.
    /// </summary>
    public static class HighestValuePalindrome
    {
        public static void Solve()
        {
            var numberOfChanges = int.Parse(Console.ReadLine().Split()[1]);
            var inputString = Console.ReadLine();
            var result = highestValuePalindrome(inputString, inputString.Length, numberOfChanges);
            Console.WriteLine(result ?? "-1");
        }

        private static string highestValuePalindrome(string inputString, int len, int numberOfChanges)
        {
            const char maximumCharacter = '9';
            var input = inputString.ToCharArray();

            // lets first check where are we about palindrome
            var differences = 0;
            for (var i = 0; i < len / 2; i++)
            {
                if (input[i] != input[len - i - 1])
                {
                    differences++;
                }
            }

            // we can't even make this palindrome
            if (differences > numberOfChanges)
                return null;

            var index = 0;
            var extras = numberOfChanges - differences;

            for (; index < len / 2; index++)
            {
                // if numbers are equal and maximum, continue
                if(input[index] == input[len - index - 1] && input[index] == maximumCharacter)
                    continue;
                // numbers are equal but not maximum, upgrade them if have at least 2 spares
                else if (input[index] == input[len - index - 1])
                {
                    if (extras > 1)
                    {
                        input[index] = '9';
                        input[len - index - 1] = '9';
                        extras -= 2;
                    }
                }
                // numbers are not equal
                else
                {
                    // if have at least 1 spare, and the bigger one is not maximum, upgrade both of them
                    if (extras > 0 && Math.Max(input[index], input[len - index - 1]) != maximumCharacter)
                    {
                        input[index] = maximumCharacter;
                        input[len - index - 1] = maximumCharacter;
                        extras -= 1;
                    }
                    // have no spare or no need to upgrade, just use regular change
                    else
                    {
                        if (input[index] > input[len - index - 1])
                            input[len - index - 1] = input[index];
                        else
                            input[index] = input[len - index - 1];
                    }
                }
            }

            // we did not consider middle of string when input has odd number of elements
            if (input.Length % 2 != 0 && extras > 0 && input[index] != maximumCharacter)
            {
                input[index] = maximumCharacter;
            }

            return new string(input);
        }
    }
}
