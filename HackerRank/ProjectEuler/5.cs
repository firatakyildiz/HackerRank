using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.ProjectEuler
{
    /// <summary>
    /// Link : https://www.hackerrank.com/contests/projecteuler/challenges/euler005/problem
    /// Difficulty : Medium
    /// Solution : The answer is the smallest common multiple of all the values up to N.
    /// To find it, we just find the prime factors of each value up to N, and merge them. 
    /// </summary>
    public static class _5
    {
        public static void Solve()
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < numberOfTestCases; i++)
            {
                var number = Convert.ToInt32(Console.ReadLine());
                var dic = new Dictionary<int, int>();
                for (int j = 2; j <= number; j++)
                {
                    var factors = Factorize(j);
                    AddFactors(dic, factors);
                }
                var result = 1L;
                foreach (var item in dic.ToList())
                {
                    result *= (long)Math.Pow(item.Key, item.Value);
                }
                Console.WriteLine(result);
            }
        }

        private static Dictionary<int, int> AddFactors(Dictionary<int, int> dic, Dictionary<int, int> factors)
        {
            foreach (var item in factors)
            {
                dic.TryGetValue(item.Key, out var existingValue);
                var newValue = (int)Math.Max(existingValue, item.Value);
                dic[item.Key] = newValue;
            }
            return dic;
        }

        private static Dictionary<int, int> Factorize(int number)
        {
            var dic = new Dictionary<int, int>();
            var factorsOf2 = GetFactors(ref number, 2);
            dic[2] = factorsOf2;
            var factor = 3;
            
            while (number >= factor)
            {
                var value = GetFactors(ref number, factor);
                dic[factor] = value;
                factor += 2;
            }
            return dic;
        }

        private static int GetFactors(ref int number, int factor)
        {
            var count = 0;
            while (number >= factor)
            {
                if (number % factor == 0)
                {
                    count++;
                    number /= factor;
                }
                else
                    break;
            }
            return count;
        }
    }
}
