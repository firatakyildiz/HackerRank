using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/sock-merchant/problem
    /// Difficulty : Easy
    /// Note : String.Split() with StringSplitOptions is not present in hackerrank C# version,
    /// and some input has extra whitespace. Therefore, Trim().
    /// </summary>
    public static class SockMerchant
    {
        public static void Solve()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] ar = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
            int result = sockMerchant(n, ar);
            Console.WriteLine(result);
        }

        private static int sockMerchant(int len, int[] arr)
        {
            var dic = new Dictionary<int,int>();
            foreach (var index in arr)
            {
                if (!dic.ContainsKey(index))
                    dic[index] = 1;
                else
                    dic[index] = dic[index] + 1;
            }

            var count = 0;
            foreach (var keyValuePair in dic.ToList())
            {
                count += keyValuePair.Value / 2;
            }

            return count;
        }
    }
}
