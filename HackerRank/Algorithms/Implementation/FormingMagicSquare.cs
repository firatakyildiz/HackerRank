using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/magic-square-forming/problem
    /// Difficulty : Medium
    /// Note : What started as a joke transformed into a real solution since there is
    /// no easy way to solve the problem without pre-computing all possible magic
    /// squares.
    /// </summary>
    public static class FormingMagicSquare
    {
        public static void Solve()
        {
            int[][] s = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                s[i] = Array.ConvertAll(Console.ReadLine().Split(' '), sTemp => Convert.ToInt32(sTemp));
            }
            int result = formingMagicSquare(s);
            Console.WriteLine(result);
        }

        private static int formingMagicSquare(int[][] ints)
        {
            const int magicNumber = 3;
            var allMagicSquares = new int[][][]
            {
                new int[][] {new []{8,1,6},new []{3,5,7},new []{4,9,2}},
                new int[][] {new []{6,1,8},new []{7,5,3},new []{2,9,4}},
                new int[][] {new []{4,9,2},new []{3,5,7},new []{8,1,6}},
                new int[][] {new []{2,9,4},new []{7,5,3},new []{6,1,8}},
                new int[][] {new []{8,3,4},new []{1,5,9},new []{6,7,2}},
                new int[][] {new []{4,3,8},new []{9,5,1},new []{2,7,6}},
                new int[][] {new []{6,7,2},new []{1,5,9},new []{8,3,4}},
                new int[][] {new []{2,7,6},new []{9,5,1},new []{4,3,8}}
            };
            var foundMinimum = int.MaxValue;
            foreach (var magicSquare in allMagicSquares)
            {
                var count = 0;
                for (int i = 0; i < magicNumber; i++)
                {
                    for (int j = 0; j < magicNumber; j++)
                    {
                        count += Math.Abs(magicSquare[i][j] - ints[i][j]);
                    }
                }
                if (count < foundMinimum)
                    foundMinimum = count;
            }
            return foundMinimum;
        }
    }
}
