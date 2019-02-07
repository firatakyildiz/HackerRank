using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/bigger-is-greater/problem
    /// Difficulty : Medium
    /// Solution : For a given string, next smallest lexicographically greater string can be found by first
    /// find longest non-increasing suffix. This substring is already at maximum value, so we have to
    /// change input string starting with the element just before it. If there is no element before this
    /// substring, than our input string is already lexicographically greatest that it can be.
    /// Then, in order to increase original string's value as minimum as possible, we find the rightmost
    /// character which is greater than the element where the change will begin. We swap those elements,
    /// and then reorder found substring in ascending order. Since we know that the substring is
    /// in descending order, we could reverse it instead of sorting.
    /// </summary>
    public static class BiggerIsGreater
    {
        public static void Solve()
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfTestCases; i++)
            {
                var input = Console.ReadLine();
                var output = biggerIsGreater(input);
                Console.WriteLine(output ?? "no answer");
            }
        }

        private static string biggerIsGreater(string inputString)
        {
            var input = inputString.ToCharArray();
            var firstIndex = input.Length - 1;
            var secondIndex = input.Length - 1;

            // find longest non-increasing suffix of the input string
            while (firstIndex > 0 && input[firstIndex - 1] >= input[firstIndex])
                firstIndex--;

            // this means input string is fully in non-increasing order, so there is no greater
            // lexicographical permutation 
            if (firstIndex == 0)
                return null;

            // find the first(last) value that is greater than the element
            // which broke the non-increasing prefix sequence
            while (input[secondIndex] <= input[firstIndex - 1])
                secondIndex--;

            // swap those elements
            var temp = input[firstIndex - 1];
            input[firstIndex - 1] = input[secondIndex];
            input[secondIndex] = temp;

            // reverse earlier found suffix
            secondIndex = input.Length - 1;
            while (firstIndex < secondIndex)
            {
                temp = input[firstIndex];
                input[firstIndex] = input[secondIndex];
                input[secondIndex] = temp;
                firstIndex++;
                secondIndex--;
            }
            
            return new string(input);
        }
    }
}
