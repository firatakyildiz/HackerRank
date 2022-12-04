using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.ProjectEuler
{
    /// <summary>
    /// Link : https://www.hackerrank.com/contests/projecteuler/challenges/euler009/problem
    /// Difficulty : Easy
    /// Solution : There are 2 equations and 3 variables. So we can write 2 variables with regards to the other one.
    /// Also since a is the smallest number, it can not be greater than N / 3
    /// </summary>
    public static class _9
    {
        public static void Solve()
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < numberOfTestCases; i++)
            {
                var N = Convert.ToInt32(Console.ReadLine());
                var largestProduct = -1;
                for (var a = 1; a <= N / 3; a++)
                {
                    var b = (N * N - 2 * a * N) / (2 * N - 2 * a);
                    var c = N - b - a;

                    // make sure b is an integer (a and c are both integers at this point)
                    if ((N * N - 2 * a * N) % (2 * N - 2 * a) == 0)
                    {
                        var product = a * b * c;
                        if(product != 0 && product > largestProduct)
                            largestProduct = product;
                    }
                }
                Console.WriteLine(largestProduct);
            }
        }
    }
}
