using System;
using System.Collections.Generic;

namespace HackerRank.DataStructures.Stacks
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/balanced-brackets/problem
    /// Difficulty : Medium
    /// </summary>
    public static class BalancedBrackets
    {
        private static string IsBalanced(string s)
        {
            var stack = new Stack<char>();
            var result = true;
            foreach (var c in s)
            {
                switch (c)
                {
                    case '(':
                    case '[':
                    case '{':
                        stack.Push(c);
                        break;
                    case ')':
                        if (stack.Count == 0)
                        {
                            result = false;
                            break;
                        }
                        if (stack.Pop() != '(')
                            result = false;
                        break;
                    case ']':
                        if (stack.Count == 0)
                        {
                            result = false;
                            break;
                        }
                        if (stack.Pop() != '[')
                            result = false;
                        break;
                    case '}':
                        if (stack.Count == 0)
                        {
                            result = false;
                            break;
                        }
                        if (stack.Pop() != '{')
                            result = false;
                        break;
                }
                if (!result) break;
            }
            if (stack.Count != 0)
                result = false;
            return result ? "YES" : "NO";
        }

        public static void Solve()
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < numberOfTestCases; i++)
            {
                Console.WriteLine(IsBalanced(Console.ReadLine()));
            }
        }
    }
}
