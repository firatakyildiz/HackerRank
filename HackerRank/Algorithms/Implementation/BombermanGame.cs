using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/bomber-man/problem
    /// Difficulty : Medium
    /// Solution : The board will have only a few different states, no matter the input.
    /// See comments for details.
    /// </summary>
    public static class BombermanGame
    {
        public static void Solve()
        {
            //string[] rcn = Console.ReadLine().Split(' ');
            //int r = Convert.ToInt32(rcn[0]);
            //int c = Convert.ToInt32(rcn[1]);
            //int n = Convert.ToInt32(rcn[2]);
            //string[] grid = new string[r];
            //for (int i = 0; i < r; i++)
            //{
            //    string gridItem = Console.ReadLine();
            //    grid[i] = gridItem;
            //}
            var grid = new[] { "O..OO........O..O........OO.O.OO.OO...O.....OOO...OO.O..OOOOO...O.O..O..O.O..OOO..O..O..O....O...O....O...O..O..O....O.O.O.O.....O.....OOOO..O......O.O.....OOO....OO....OO....O.O...O..OO....OO..O...O" };
            var n = 181054341;
            string[] result = bomberMan(n, grid);
            Console.WriteLine(string.Join("\n", result));
        }

        private static string[] FullGrid(int numRows, int numCols)
        {
            var grid = new string[numRows];
            for (var i = 0; i < numRows; i++)
            {
                grid[i] = "".PadRight(numCols, 'O');
            }
            return grid;
        }

        private static string[] bomberMan(int time, string[] grid)
        {
            var numRows = grid.Length;
            var numCols = grid[0].Length;

            // nothing has changed, return input
            if (time == 1)
                return grid;
            // since bombs are put at even times, board is always full
            else if (time % 2 == 0)
                return FullGrid(numRows, numCols);

            // calculate and store board for 5 turns,
            // since board will repeat itself indefinitely
            var current = ConvertToIntMatrix(grid, numRows, numCols);
            var history = new List<int[,]> { current };
            var plantBombs = false;
            for (var i = 0; i < 5; i++)
            {
                current = AdvanceTime(current, numRows, numCols, plantBombs);
                history.Add(current);
                plantBombs = !plantBombs;
            }
            // there are only 2 different states the board can be in.
            // calculate what will be the state like at required time.
            // return corresponding one from history
            time = time % 4;
            if (time == 1)
                return ConvertToStringMatrix(history[5], numRows, numCols);
            // else if time == 3
            return ConvertToStringMatrix(history[3], numRows, numCols);
        }

        private static int[,] AdvanceTime(int[,] grid, int rows, int cols, bool fill)
        {
            var nextGrid = new int[rows,cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    nextGrid[row, col] = -1;
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] == 1)
                    {
                        Explode(ref nextGrid, i, j, rows, cols);
                    }
                    else if (nextGrid[i, j] == 0)
                    {
                        continue;
                    }
                    else if (grid[i, j] == 0)
                    {
                        nextGrid[i, j] = fill ? 3 : 0;
                    }
                    else
                    {
                        nextGrid[i, j] = grid[i, j] - 1;
                    }
                    //switch (grid[i,j])
                    //{
                    //    case 3:
                    //        nextGrid[i, j] = 2;
                    //        break;
                    //    case 2:
                    //        nextGrid[i, j] = 1;
                    //        break;
                    //    case 0:
                    //        nextGrid[i, j] = fill ? 3 : 0;
                    //        break;
                    //    default:
                    //        Explode(ref nextGrid, i, j, rows, cols);
                    //        break;
                    //}
                }
            }
            return nextGrid;
        }

        private static void Explode(ref int[,] nextGrid, int row, int col, int numRows, int numCols)
        {
            nextGrid[row, col] = 0;
            if (row != 0)
                nextGrid[row - 1, col] = 0;
            if (row != numRows - 1)
                nextGrid[row + 1, col] = 0;
            if (col != 0)
                nextGrid[row, col - 1] = 0;
            if (col != numCols - 1)
                nextGrid[row, col + 1] = 0;
        }

        private static int[,] ConvertToIntMatrix(string[] grid, int numRows, int numCols)
        {
            var intGrid = new int[numRows, numCols];
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    switch (grid[i][j])
                    {
                        case '.': intGrid[i, j] = 0;
                            break;
                        case 'O': intGrid[i, j] = 3;
                            break;
                    }
                }
            }
            return intGrid;
        }

        private static string[] ConvertToStringMatrix(int[,] grid, int numRows, int numCols)
        {
            var arr = new string[numRows];
            var builder = new StringBuilder(numCols);
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    switch (grid[i,j])
                    {
                        case 3:
                        case 2:
                        case 1:
                            builder.Append('O');break;
                        case 0:
                            builder.Append('.');
                            break;
                    }
                }
                arr[i] = builder.ToString();
                builder.Clear();
            }
            return arr;
        }
        
    }
}
