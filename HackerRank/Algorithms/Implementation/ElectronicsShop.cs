using System;
using System.IO;
using System.Linq;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/electronics-shop/problem
    /// Difficulty : Easy
    /// </summary>
    public static class ElectronicsShop
    {
        public static void Solve()
        {
            var budget = Convert.ToInt32(Console.ReadLine().Split()[0]);
            var keyboards = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var sticks = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var result = (from k in keyboards
                from s in sticks
                where k + s <= budget
                select k + s).DefaultIfEmpty(-1).Max();
            Console.WriteLine(result);
        }
    }
}
