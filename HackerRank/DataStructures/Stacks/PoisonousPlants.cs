using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace HackerRank.DataStructures.Stacks
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/poisonous-plants/problem
    /// Difficulty : Hard
    /// </summary>
    public class PoisonousPlants
    {
        public static void Solve()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] p = Array.ConvertAll(Console.ReadLine().Split(' '), pTemp => Convert.ToInt32(pTemp));
            int result = poisonousPlants(p);
            Console.WriteLine(result);
        }

        private static int poisonousPlants(int[] arr)
        {
            var limit = arr[0];
            var lifetimes = new int[arr.Length];
            var maxLifetime = 0;
            var stack = new Stack<int>();
            stack.Push(0);

            for (var i = 1; i < arr.Length; i++)
            {
                // all plants with values greater than this will die at some point.
                // we have to calculate the lifetimes of these plants.
                limit = Math.Min(limit, arr[i]);
                
                // this plant will die at day 1
                if (arr[i] > arr[i - 1])
                    lifetimes[i] = 1;

                // push items into stack until incoming is not greater then top of stack
                // then calculate its lifetime from stack contents
                while (stack.Any())
                {
                    var index = stack.Peek();
                    if (arr[i] > arr[index])
                        break;

                    if (arr[i] > limit)
                    {
                        lifetimes[i] = Math.Max(lifetimes[i], lifetimes[index] + 1);
                    }
                    stack.Pop();
                }

                maxLifetime = Math.Max(lifetimes[i], maxLifetime);
                stack.Push(i);
            }
            return maxLifetime;
        }
    }
}
