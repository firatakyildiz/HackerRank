using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.Heaps
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/jesse-and-cookies/problem
    /// Difficulty : Easy
    /// Explanation : Insert all cookies into a min heap. Pop elements, do the calculation and push
    /// new elements until popped element is greater than threshold value.
    /// </summary>
    public static class JesseAndCookies
    {
        public static void Solve()
        {
            var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var sweetness = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var result = cookies(arr[1], sweetness);
            Console.WriteLine(result);
        }

        private static int cookies(int sweetness, int[] cookies)
        {
            _elements = new List<int>();
            foreach (var cookie in cookies)
            {
                Add(cookie);
            }

            var numberOfOperations = 0;
            while (_elements.Count != 0)
            {
                var first = Pop();
                if (first >= sweetness)
                    break;
                if (_elements.Count == 0)
                    return -1;
                var second = Pop();
                var newCookie = first + 2 * second;
                Add(newCookie);
                numberOfOperations++;
            }
            return numberOfOperations;
        }

        private static List<int> _elements;

        private static void Swap(int firstIndex, int secondIndex)
        {
            var temp = _elements[firstIndex];
            _elements[firstIndex] = _elements[secondIndex];
            _elements[secondIndex] = temp;
        }

        private static int Pop()
        {
            if (_elements.Count == 0)
                throw new IndexOutOfRangeException();

            var result = _elements[0];
            _elements[0] = _elements[_elements.Count - 1];
            _elements.RemoveAt(_elements.Count - 1);

            ReCalculateDown();

            return result;
        }

        private static void Add(int element)
        {
            _elements.Add(element);
            ReCalculateUp();
        }

        private static void ReCalculateDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (_elements[smallerIndex] >= _elements[index])
                {
                    break;
                }

                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }

        private static void ReCalculateUp()
        {
            var index = _elements.Count - 1;
            while (index != 0 && _elements[index] < GetParent(index))
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }

        private static int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        private static int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
        private static int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

        private static bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _elements.Count;
        private static bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _elements.Count;

        private static int GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
        private static int GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
        private static int GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];
    }
}

            
            

