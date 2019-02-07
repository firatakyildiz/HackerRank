using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.DataStructures.Advanced
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/find-maximum-index-product/problem
    /// Difficulty : Medium
    /// Solution : Left index and right index can be found separately within time constraints.
    /// Use a stack to keep track of possible maximums while traversing.
    /// </summary>
    public static class FindMaximumIndexProduct
    {
        public static void Solve()
        {
            int arrCount = Convert.ToInt32(Console.ReadLine());
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            var result = solve(arr);
            Console.WriteLine(result);
        }

        private static long solve(int[] arr)
        {
            var stack = new Stack<int>();
            var leftIndexProducts = new int[arr.Length];
            var rightIndexProducts = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                while (stack.Any() && arr[i] >= arr[stack.Peek()])
                    stack.Pop();

                if (!stack.Any())
                {
                    stack.Push(i);
                    leftIndexProducts[i] = 0;
                }
                else
                {
                    leftIndexProducts[i] = stack.Peek() + 1;
                    stack.Push(i);
                }
            }
            stack.Clear();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                while (stack.Any() && arr[i] >= arr[stack.Peek()])
                    stack.Pop();

                if (!stack.Any())
                {
                    stack.Push(i);
                    rightIndexProducts[i] = 0;
                }
                else
                {
                    rightIndexProducts[i] = stack.Peek() + 1;
                    stack.Push(i);
                }
            }

            var maximumProduct = 0L;
            for (int i = 0; i < arr.Length; i++)
            {
                var value = (long)leftIndexProducts[i] * rightIndexProducts[i];
                if (value > maximumProduct)
                    maximumProduct = value;
            }
            return maximumProduct;
        }
    }
}
