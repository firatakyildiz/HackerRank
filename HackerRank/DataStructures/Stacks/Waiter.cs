using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.Stacks
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/waiter/problem
    /// Difficulty : Medium
    /// </summary>
    public class Waiter
    {
        public static void Solve()
        {
            string[] nq = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nq[0]);
            int q = Convert.ToInt32(nq[1]);
            int[] number = Array.ConvertAll(Console.ReadLine().Split(' '), numberTemp => Convert.ToInt32(numberTemp));
            int[] result = waiter(number, q);
            Console.WriteLine(string.Join("\n", result));
        }

        static int[] waiter(int[] initialArray, int numberOfIterations)
        {
            var stackA = new Stack<int>();
            var stackB = new Stack<int>();
            var origin = new Stack<int>();
            var list = new List<Stack<int>>();
            foreach (var item in initialArray)
            {
                origin.Push(item);
            }
            using (var prime = GetEnumerator())
            {
                for (int i = 0; i < numberOfIterations; i++)
                {
                    prime.MoveNext();
                    while (origin.Count != 0)
                    {
                        var item = origin.Pop();
                        if (item % prime.Current == 0)
                        {
                            stackB.Push(item);
                        }
                        else
                        {
                            stackA.Push(item);
                        }
                    }
                    origin = stackA;
                    stackA = new Stack<int>();
                    list.Add(stackB);
                    stackB = new Stack<int>();
                }
            }
            var returnArray = new int[initialArray.Length];
            var index = 0;
            for (int i = 0; i < list.Count; i++)
            {
                while(list[i].Count != 0)
                    returnArray[index++] =  list[i].Pop();
            }
            while(origin.Count != 0)
                returnArray[index++] = origin.Pop();
            return returnArray;
        }

        private static bool IsOddPrime(int value)
        {
            var sqrt = (int)Math.Sqrt(value);
            for (var i = 3; i <= sqrt; i += 2)
                if (value % i == 0) return false;

            // If we get here, value is prime.
            return true;
        }

        private static IEnumerator<int> GetEnumerator()
        {
            yield return 2;
            for (var i = 3; ; i += 2)
                if (IsOddPrime(i)) yield return i;
        }
    
    }
}
