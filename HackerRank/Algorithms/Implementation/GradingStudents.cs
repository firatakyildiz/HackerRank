using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/grading/problem
    /// Difficulty : Easy
    /// </summary>
    public static class GradingStudents
    {
        public static void Solve()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] grades = new int[n];
            for (int gradesItr = 0; gradesItr < n; gradesItr++)
            {
                int gradesItem = Convert.ToInt32(Console.ReadLine());
                grades[gradesItr] = gradesItem;
            }
            int[] result = gradingStudents(grades);
            Console.WriteLine(string.Join("\n", result));
        }

        private static int[] gradingStudents(int[] grades)
        {
            return grades.Select(x => x < 38 || x % 5 == 0 || x % 5 < 3 ? x : x + (5 - x % 5)).ToArray();
        }
    }
}
