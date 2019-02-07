using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.DataStructures.Advanced
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/jim-and-the-skyscrapers/problem
    /// Difficulty : Medium
    /// Note : Sample code is wrong. Function return type overflows with int.
    /// </summary>
    public static class JimAndTheSkyscrapers
    {
        public static void Solve()
        {
            var numberOfSkyScrapers = Console.ReadLine();
            var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var result = solve(arr);
            Console.WriteLine(result);
        }

        private static long solve(int[] arr)
        {
            var count = 0L;
            var stack = new Stack<Path>();
            for (int i = 0; i < arr.Length; i++)
            {
                var height = arr[i];
                // a higher building removes the chance of any further paths
                // for previous elements.
                while (stack.Any() && height > stack.Peek().Height)
                    stack.Pop();
                // if stack is empty, or the current is smaller than top of the stack
                // push current height
                if (!stack.Any() || height < stack.Peek().Height)
                    stack.Push(new Path {Height = height, Count = 1});
                // each new element to N locations creates N more paths
                else //if (stack.Peek().Height == height)
                {
                    count += stack.Peek().Count;
                    stack.Peek().Count++;
                }
            }
            // All paths also have a reverse direction
            return count * 2;
        }

        // Because the Tuple class is immutable
        private class Path
        {
            public int Height { get; set; }
            public int Count { get; set; }
        }
    }
}
