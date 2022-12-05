using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit.Day2
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/one-week-preparation-kit-lonely-integer/problem
    /// Difficulty : Easy
    /// Solution : If we just XOR every number in the sequence, duplicate values will cancel out each other.
    /// The result will be the unique number.
    /// </summary>
    public static class LonelyInteger
    {
        public static void Solve()
        {
            var n = Console.ReadLine();
            var array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var result = array.Aggregate(0, (current, number) => current ^ number);
            Console.WriteLine(result);
        }
    }
}
