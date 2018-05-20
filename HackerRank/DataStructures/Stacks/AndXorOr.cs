using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.Stacks
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/waiter/problem
    /// Difficulty : Hard
    /// Explanation: The complex logical equation is actually equal to M_1 XOR M_2. 
    /// Since there are only 2 variables, truth table can be easily constructed to prove this.
    /// In addition, finding every pair of smallest integers for each subarray of a given array
    /// can be found with a stack in (near) linear time.
    /// </summary>
    public class AndXorOr
    {
        public static void Solve()
        {
            int aCount = Convert.ToInt32(Console.ReadLine());

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
            int result = andXorOr(a);

            Console.WriteLine(result);
        }

        private static int andXorOr(int[] array)
        {
            var max = 0;
            var stack = new Stack<int>();
            foreach (var item in array)
            {
                while (stack.Count != 0)
                {
                    var top = stack.Peek();
                    var temp = item ^ top;
                    if (temp > max) max = temp;
                    if (item < top)
                        stack.Pop();
                    else
                        break;
                }
                stack.Push(item);
            }
            return max;
        }
    }
}
