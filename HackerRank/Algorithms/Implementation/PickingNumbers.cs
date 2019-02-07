using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/picking-numbers/problem
    /// Difficulty : Easy
    /// </summary>
    public static class PickingNumbers
    {
        public static void Solve()
        {
            var len = Console.ReadLine();
            var numbers = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var dic = new Dictionary<int,int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!dic.ContainsKey(numbers[i]))
                    dic[numbers[i]] = 1;
                else
                    dic[numbers[i]] = dic[numbers[i]] + 1;
            }

            var list = dic.OrderBy(x => x.Key).ToList();
            var maxLength = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                int length;
                if (Math.Abs(list[i].Key - list[i + 1].Key) > 1)
                    length = list[i].Value;
                else
                    length = list[i].Value + list[i + 1].Value;
                if (length > maxLength)
                    maxLength = length;
            }
            maxLength = Math.Max(maxLength, list[list.Count - 1].Value);
            Console.WriteLine(maxLength);
        }
    }
}
