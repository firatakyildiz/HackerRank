using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit.Day2
{
    /// <summary>
    /// If we examine the question, we can see that each number can only be moved to at most 4 different places.
    /// In addition, all the numbers can be moved around individually like a Rubik's Cube.
    /// So we only check the largest number that can be placed in each location.
    /// </summary>
    internal class MockTest
    {
        public static int flippingMatrix(List<List<int>> matrix)
        {
            var size = matrix.Count;
            var total = 0;
            for (var i = 0; i < size / 2; i++)
            for (var j = 0; j < size / 2; j++)
            {
                var candidate1 = matrix[i][j];
                var candidate2 = matrix[i][size - 1 - j];
                var candidate3 = matrix[size - 1 - i][j];
                var candidate4 = matrix[size - 1 - i][size - 1 - j];
                total += Math.Max(Math.Max(candidate1, candidate2), Math.Max(candidate3, candidate4));
            }
            return total;
        }
    }
}
