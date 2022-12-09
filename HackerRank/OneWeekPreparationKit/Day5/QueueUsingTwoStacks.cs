using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit.Day5
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/one-week-preparation-kit-queue-using-two-stacks/problem
    /// Difficulty : Medium
    /// Solution : We can simulate a queue by using two stacks. See the code below.
    /// </summary>
    public static class QueueUsingTwoStacks
    {
        public static void Solve()
        {
            var queue = new Queue();
            var numberOfQueries = int.Parse(Console.ReadLine());
            for (var i = 0; i < numberOfQueries; i++)
            {
                var input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                switch (input[0])
                {
                    case 1:
                        queue.Enqueue(input[1]);
                        break;
                    case 2:
                        queue.Dequeue();
                        break;
                    case 3:
                        Console.WriteLine(queue.Peek());
                        break;

                }
            }
        }

        private class Stack
        {
            private readonly List<int> _storage = new();

            public void Push(int input)
            {
                _storage.Add(input);
            }

            public int Pop()
            {
                var item = _storage[^1];
                _storage.RemoveAt(_storage.Count - 1);
                return item;
            }

            public bool IsEmpty()
            {
                return _storage.Count == 0;
            }

            public int Peek()
            {
                return _storage[^1];
            }
        }

        private class Queue
        {
            private readonly Stack _pushStack = new();
            private readonly Stack _popStack = new();

            public int Peek()
            {
                Reconstruct();
                return _popStack.Peek();
            }

            public void Enqueue(int input)
            {
                _pushStack.Push(input);
            }

            public int Dequeue()
            {
                Reconstruct();
                return _popStack.Pop();
            }

            private void Reconstruct()
            {
                if (_popStack.IsEmpty())
                {
                    while (!_pushStack.IsEmpty())
                        _popStack.Push(_pushStack.Pop());
                }
            }
        }
    }
}
