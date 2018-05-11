using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.Stacks
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/largest-rectangle/problem
    /// Difficulty : Medium
    /// </summary>
    class LargestRectangle
    {
        static long largestRectangle(int[] arr)
        {
            var positions = new Stack<int>();
            var heights = new Stack<int>();
            long maxArea = -1;
            for (var i = 0; i < arr.Length; i++)
            {
                if (positions.Count == 0)
                {
                    positions.Push(i);
                    heights.Push(arr[i]);
                }
                else
                {
                    if (arr[i] > heights.Peek())
                    {
                        positions.Push(i);
                        heights.Push(arr[i]);
                    }
                    else if (arr[i] < heights.Peek())
                    {
                        var startingPosition = 0;
                        while (arr[i] < heights.Peek())
                        {
                            startingPosition = positions.Pop();
                            long area = heights.Pop() * (i - startingPosition);
                            if (area > maxArea)
                                maxArea = area;
                            if (heights.Count == 0)
                                break;
                        }
                        positions.Push(startingPosition);
                        heights.Push(arr[i]);
                    }
                }
                if (heights.Count == 0)
                {
                    positions.Push(i);
                    heights.Push(arr[i]);
                }
            }
            while (positions.Count != 0)
            {
                long area = heights.Pop() * (arr.Length - positions.Pop());
                if (area > maxArea)
                    maxArea = area;
            }
            return maxArea;
        }

        public static void Solve()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] h_temp = Console.ReadLine().Split(' ');
            int[] h = Array.ConvertAll(h_temp, Int32.Parse);
            long result = largestRectangle(h);
            Console.WriteLine(result);
        }
    }
}
