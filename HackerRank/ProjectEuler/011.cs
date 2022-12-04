using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.ProjectEuler
{
    /// <summary>
    /// Link : https://www.hackerrank.com/contests/projecteuler/challenges/euler011/problem
    /// Difficulty : Easy
    /// Solution : Simple calculation
    /// </summary>
    public static class _011
    {
        private const int Size = 20;
        private const int ProductCount = 4;

        private enum Direction
        {
            Rightwards,
            Downwards,
            RightDiagonal,
            LeftDiagonal
        }

        public static void Solve()
        {
            var grid = new int[Size][];
            for (var i = 0; i < Size; i++)
            {
                var row = Console.ReadLine().Split(' ');
                grid[i] = Array.ConvertAll(row, int.Parse);
            }

            var largestProduct = 0;
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    largestProduct = Math.Max(largestProduct, GetMultiplication(grid, i, j, Direction.Downwards));
                    largestProduct = Math.Max(largestProduct, GetMultiplication(grid, i, j, Direction.Rightwards));
                    largestProduct = Math.Max(largestProduct, GetMultiplication(grid, i, j, Direction.RightDiagonal));
                    largestProduct = Math.Max(largestProduct, GetMultiplication(grid, i, j, Direction.LeftDiagonal));
                }
            }

            Console.WriteLine(largestProduct);
        }

        private static int GetMultiplication(int[][] grid, int row, int column, Direction direction)
        {
            var rowMultiplier = 0;
            var columnMultiplier = 0;
            switch (direction)
            {
                case Direction.Rightwards:
                    if (column + ProductCount > Size)
                        return 0;
                    rowMultiplier = 0;
                    columnMultiplier = 1;
                    break;
                case Direction.RightDiagonal:
                    if (column + ProductCount > Size)
                        return 0;
                    if(row + ProductCount >= Size)
                        return 0;
                    rowMultiplier = 1;
                    columnMultiplier = 1;
                    break;
                case Direction.LeftDiagonal:
                    if (column + ProductCount > Size)
                        return 0;
                    if (row - ProductCount < -1)
                        return 0;
                    rowMultiplier = -1;
                    columnMultiplier = 1;
                    break;
                case Direction.Downwards:
                    if (row + ProductCount >= Size)
                        return 0;
                    rowMultiplier = 1;
                    columnMultiplier = 0;
                    break;
            }

            var total = 1;
            for (var i = 0; i < ProductCount; i++)
            {
                total *= grid[row + i * rowMultiplier][column + i * columnMultiplier];
            }

            return total;
        }
    }
}
