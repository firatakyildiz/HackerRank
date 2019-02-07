using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Strings
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/strong-password/problem
    /// Difficulty : Easy
    /// </summary>
    public static class StrongPassword
    {
        public static void Solve()
        {
            var len = Console.ReadLine();
            var input = Console.ReadLine();

            var requiredCharacterGroups = new []
            {
                "0123456789",
                "abcdefghijklmnopqrstuvwxyz",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "!@#$%^&*()-+"
            };
            
            var numExtraChars = requiredCharacterGroups.Length;
            var minimumLength = 6;
            foreach (var characterGroup in requiredCharacterGroups)
            {
                foreach (var character in input)
                {
                    if (characterGroup.Contains(character))
                    {
                        numExtraChars--;
                        break;
                    }
                }
            }

            Console.WriteLine(input.Length + numExtraChars >= minimumLength ? numExtraChars : minimumLength - input.Length);
        }
    }
}
