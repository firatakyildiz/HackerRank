using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit.Day3
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/one-week-preparation-kit-caesar-cipher-1/problem
    /// Difficulty : Easy
    /// Solution : Simple calculation
    /// </summary>
    public static class CaesarCipher
    {
        private const int AlphabetSize = 26;
        private const char LowercaseA = 'a';
        private const char LowercaseZ = 'z';
        private const char UppercaseA = 'A';
        private const char UppercaseZ = 'Z';
        
        public static void Solve()
        {
            var length = Console.ReadLine();
            StringBuilder clearText = new (Console.ReadLine());
            var rotationCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < clearText.Length; i++)
            {
                if (clearText[i] >= LowercaseA && clearText[i] <= LowercaseZ)
                    clearText[i] = (char)(LowercaseA + (clearText[i] + rotationCount - LowercaseA) % AlphabetSize);
                else if (clearText[i] >= UppercaseA && clearText[i] <= UppercaseZ)
                    clearText[i] = (char)(UppercaseA + (clearText[i] + rotationCount - UppercaseA) % AlphabetSize);
            }

            Console.WriteLine(clearText.ToString());
        }
    }
}
