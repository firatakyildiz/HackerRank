using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/designer-pdf-viewer/problem
    /// Difficulty : Easy
    /// </summary>
    public static class DesignerPdfViewer
    {
        public static void Solve()
        {
            var characterHeights = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var word = Console.ReadLine();
            var maxHeight = 0;
            for (int i = 0; i < word.Length; i++)
            {
                var len = characterHeights[word[i] - 'a'];
                if (len > maxHeight)
                    maxHeight = len;
            }

            Console.WriteLine(maxHeight * word.Length);
        }
    }
}
