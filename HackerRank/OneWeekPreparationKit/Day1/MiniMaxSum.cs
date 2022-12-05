using System;
using System.Linq;

namespace HackerRank.OneWeekPreparationKit.Day1
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/one-week-preparation-kit-mini-max-sum/problem
    /// Difficulty : Easy
    /// Solution : For the biggest sum of 4 numbers, find the minimum number and subtract it from the total.
    /// For the smallest sum, do the same with the maximum number
    /// </summary>
    public static class MiniMaxSum
    {
        public static void Solve()
        {
            var arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            var min = int.MaxValue;
            var max = 0;
            var total = 0L;
            
            foreach (var item in arr)
            {
                if(item < min)
                    min = item;
                if(item > max) 
                    max = item;
                total += item;
            }

            Console.WriteLine((total - max) + " " + (total - min));
        }
    }
}
