using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit.Day3
{
    /// <summary>
    /// There are at most 2 cases. Whenever a character tuple makes the string not palindrome, remove both characters and
    /// test remaining strings for being a palindrome.
    /// </summary>
    internal class MockTest
    {
        public static int palindromeIndex(string s)
        {
            for (var i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    var firstCandidate = s.Remove(i, 1);
                    var secondCandidate = s.Remove(s.Length - 1 - i, 1);

                    if (isPalindrome(firstCandidate))
                        return i;

                    if (isPalindrome(secondCandidate))
                        return s.Length - 1 - i;

                    return -1;
                }
            }
            return -1;
        }

        private static bool isPalindrome(string s)
        {
            for (var i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            }

            return true;
        }
    }
}
