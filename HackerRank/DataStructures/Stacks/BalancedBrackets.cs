using System;
using System.Collections.Generic;

namespace HackerRank.DataStructures.Stacks
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/balanced-brackets/problem
    /// Difficulty : Medium
    /// </summary>
    class BalancedBrackets
    {
        private static string isBalanced(string s)
        {
            var stack = new Stack<char>();
            var result = true;
            foreach (var c in s)
            {
                char openingCharacter;
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
                        openingCharacter = stack.Pop();
                        if (openingCharacter != '(')
                            result = false;
                        break;
                    case ']':
                        if (stack.Count == 0)
                        {
                            result = false;
                            break;
                        }
                        openingCharacter = stack.Pop();
                        if (openingCharacter != '[')
                            result = false;
                        break;
                    case '}':
                        if (stack.Count == 0)
                        {
                            result = false;
                            break;
                        }
                        openingCharacter = stack.Pop();
                        if (openingCharacter != '{')
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
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                string s = Console.ReadLine();
                string result = isBalanced(s);
                Console.WriteLine(result);
            }
        }
    }
}
