using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/halloween-sale/problem
    /// Difficulty : Easy
    /// </summary>
    public static class HalloweenSale
    {
        public static void Solve()
        {
            var inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var cost = inputs[0];
            var discount = inputs[1];
            var minimumCost = inputs[2];
            var totalMoney = inputs[3];
            var count = 0;
            while (cost > minimumCost && totalMoney >= cost)
            {
                count++;
                totalMoney -= cost;
                cost -= discount;
            }

            count += totalMoney / Math.Max(cost, minimumCost);
            Console.WriteLine(count);
        }
    }
}
