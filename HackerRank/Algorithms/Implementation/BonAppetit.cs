using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/bon-appetit/problem
    /// Difficulty : Easy
    /// </summary>
    public static class BonAppetit
    {
        public static void Solve()
        {
            string[] nk = Console.ReadLine().TrimEnd().Split(' ');
            int n = Convert.ToInt32(nk[0]);
            int k = Convert.ToInt32(nk[1]);
            List<int> bill = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(billTemp => Convert.ToInt32(billTemp)).ToList();
            int b = Convert.ToInt32(Console.ReadLine().Trim());
            bonAppetit(bill, k, b);
        }

        static void bonAppetit(List<int> bill, int excludeIndex, int paidAmount)
        {
            var correctAmount = (bill.Sum() - bill[excludeIndex]) / 2;
            if(paidAmount == correctAmount)
                Console.WriteLine("Bon Appetit");
            else
                Console.WriteLine(paidAmount - correctAmount);
        }
    }
}
