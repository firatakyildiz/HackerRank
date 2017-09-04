using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.Arrays
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/arrays-ds
    /// Difficulty : Easy
    /// </summary>
    class ArraysDs
    {
        public static void Solve() {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            for (int i = n -1 ; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
