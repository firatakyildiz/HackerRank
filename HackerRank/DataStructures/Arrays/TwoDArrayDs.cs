using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.Arrays
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/2d-array
    /// Difficulty : Easy
    /// </summary>
    class TwoDArrayDs
    {
        private const int size = 6;
        public static void Solve() {
            int[][] arr = new int[size][];
            var total = int.MinValue;
            for (int arr_i = 0; arr_i < size; arr_i++)
            {
                string[] arr_temp = Console.ReadLine().Split(' ');
                arr[arr_i] = Array.ConvertAll(arr_temp, Int32.Parse);
            }

            for (int i = 0; i < size - 2; i++)
            {
                for (int j = 0; j < size - 2; j++)
                {
                    var currentTotal = arr[i][j] + arr[i][j + 1] + arr[i][j + 2]
                                                 + arr[i + 1][j + 1]
                                      + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
                    total = Math.Max(total, currentTotal);
                }
            }
            Console.WriteLine(total);
        }
    }
}
