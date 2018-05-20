using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.DataStructures.Queues
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/queue-using-two-stacks/problem
    /// Difficulty : Easy
    /// </summary>
    class QueueUsingTwoStacks
    {
        public static void Solve()
        {
            var numberOfQueries = Convert.ToInt32(Console.ReadLine());
            var stack1 = new Stack<int>();
            var stack2 = new Stack<int>();
            for (int i = 0; i < numberOfQueries; i++)
            {
                var input = Console.ReadLine().Trim();
                switch (input[0])
                {
                    case '1':
                        var arg = Convert.ToInt32(input.Split(' ')[1]);
                            stack1.Push(arg);
                        break;
                    case '2':
                        if (stack2.Any())
                        {
                            stack2.Pop();
                        }
                        else
                        {
                            while(stack1.Any())
                                stack2.Push(stack1.Pop());
                            stack2.Pop();
                        }
                        break;
                    case '3':
                        if (stack2.Any())
                        {
                            Console.WriteLine(stack2.Peek());
                        }
                        else
                        {
                            while (stack1.Any())
                                stack2.Push(stack1.Pop());
                            Console.WriteLine(stack2.Peek());
                        }
                        break;
                }
            }
        }
    }
}
