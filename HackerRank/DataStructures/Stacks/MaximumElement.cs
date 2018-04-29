using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.DataStructures.Stacks
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/maximum-element/problem
    /// Difficulty : Easy
    /// </summary>
    class MaximumElement
    {
        public static void Solve()
        {
            var count = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            // computing maxValue when needed was giving timeouts.
            var max = int.MinValue;
            for (var i = 0; i < count; i++)
            {
                var arr = Array.ConvertAll(Console.ReadLine().Split(),int.Parse);
                switch (arr[0])
                {
                    case 1:
                        if (arr[1] > max)
                        {
                            max = arr[1];
                        }
                        stack.Push(arr[1]);
                        break;
                    case 2:
                        stack.Pop();
                        max = stack.Any() ? stack.Max() : int.MinValue;
                        break;
                    case 3:
                        Console.WriteLine(max);
                        break;
                }
            }
        }
    }
}
