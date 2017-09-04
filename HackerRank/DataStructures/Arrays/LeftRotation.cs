using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.Arrays
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/array-left-rotation
    /// Difficulty : Easy
    /// </summary>
    class LeftRotation
    {
        public static void Solve() {
            var temp = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var numberOfIntegers = temp[0];
            var rotationCount = temp[1];
            var arr = new int[numberOfIntegers];
            rotationCount %= numberOfIntegers; // each n(array size) rotation will reset the array to its original value,no need to do them
            var originalArr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            for (int i = 0; i < numberOfIntegers; i++)
            {
                arr[(i - rotationCount + numberOfIntegers) % numberOfIntegers] = originalArr[i];
            }
            for (int i = 0; i < numberOfIntegers; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
