using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/3d-surface-area/problem
    /// Difficulty : Medium
    /// </summary>
    public static class _3DSurfaceArea
    {
        public static void Solve()
        {
            string[] HW = Console.ReadLine().Split(' ');
            int H = Convert.ToInt32(HW[0]);
            int W = Convert.ToInt32(HW[1]);
            int[][] A = new int[H][];
            for (int i = 0; i < H; i++)
            {
                A[i] = Array.ConvertAll(Console.ReadLine().Split(' '), ATemp => Convert.ToInt32(ATemp));
            }
            int result = surfaceArea(A);
            Console.WriteLine(result);
        }

        private static int surfaceArea(int[][] arr)
        {
            if (arr == null || arr.Length == 0 || arr[0].Length == 0)
                return 0;
            var height = arr.Length;
            var width = arr[0].Length;
            // top and bottom of the structure always have the same area
            var totalCost = 2 * width * height;
            for (int row = 0; row < height; row++)
            {
                var cellCost = 0;
                for (int column = 0; column < width; column++)
                {
                    // front and back costs, these could be also handled
                    // at costFromNeighbors method
                    if (row == 0) 
                        cellCost += arr[row][column];
                    if(row == height - 1)
                        cellCost += arr[row][column];
                    // left and right costs, these could be also handled
                    // at costFromNeighbors method
                    if (column == 0)
                        cellCost += arr[row][column];
                    if (column == width - 1)
                        cellCost += arr[row][column];
                    cellCost += costFromNeighbors(arr, row, column);
                }
                totalCost += cellCost;
            }
            return totalCost;
        }


        /// <summary>
        /// Surface area is increased with respect to each cell's height
        /// difference from its neighbors
        /// </summary>
        private static int costFromNeighbors(int[][] arr, int row, int column)
        {
            var cost = 0;
            var difference = 0;
            if (row != 0)
            {
                difference = arr[row][column] - arr[row - 1][column];
                if (difference> 0)
                    cost += difference;
            }

            if (row != arr.Length - 1)
            {
                difference = arr[row][column] - arr[row + 1][column];
                if (difference > 0)
                    cost += difference;
            }

            if (column != 0)
            {
                difference = arr[row][column] - arr[row][column - 1];
                if (difference > 0)
                    cost += difference;
            }

            if (column != arr[row].Length - 1)
            {
                difference = arr[row][column] - arr[row][column + 1];
                if (difference > 0)
                    cost += difference;
            }

            return cost;
        }

    }
}
