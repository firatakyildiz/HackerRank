using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.ProjectEuler
{
    /// <summary>
    /// Link : https://www.hackerrank.com/contests/projecteuler/challenges/euler008/problem
    /// Difficulty : Easy
    /// Solution : Simple calculation
    /// </summary>
    public static class _8
    {
        public static void Solve()
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < numberOfTestCases; i++)
            {
                var args = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                var inputNumber = Console.ReadLine();
                var largestProduct = 0L;
                for (int j = 0; j <= args[0] - args[1]; j++)
                {
                    var chars = inputNumber.Substring(j, args[1]);
                    var currentProduct = GetProduct(chars);
                    if(currentProduct > largestProduct)
                        largestProduct = currentProduct;
                }

                Console.WriteLine(largestProduct);
            }
        }

        private static long GetProduct(string number)
        {
            var product = 1L;
            for (int i = 0; i < number.Length; i++)
            {
                product *= (int) (number[i] - '0');
            }
            return product;
        }
    }
}
