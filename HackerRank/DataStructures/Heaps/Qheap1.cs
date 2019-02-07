using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.Heaps
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/qheap1/problem
    /// Difficulty : Easy
    /// Explanation : To perform deletion in O(1), keep track of deleted elements in a hashmap.
    /// When printing smallest, if candidate is deleted, remove it from the heap and continue.
    /// </summary>
    public static class Qheap1
    {
        public static void Solve()
        {
            _deletedElements = new Dictionary<int, bool>();
            _elements = new List<int>();
            var numberOfQueries = int.Parse(Console.ReadLine());
            _elements.Capacity = numberOfQueries;
            for (int i = 0; i < numberOfQueries; i++)
            {
                var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                switch (arr[0])
                {
                    case 1: Add(arr[1]);
                        break;
                    case 2: Delete(arr[1]);
                        break;
                    case 3: PrintMinimum();
                        break;
                }
            }
        }

        private static List<int> _elements;
        private static Dictionary<int, bool> _deletedElements;

        private static void Swap(int firstIndex, int secondIndex)
        {
            var temp = _elements[firstIndex];
            _elements[firstIndex] = _elements[secondIndex];
            _elements[secondIndex] = temp;
        }

        private static void Delete(int number)
        {
            _deletedElements[number] = true;
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
            var exists = _deletedElements.ContainsKey(element);
            if (exists)
                _deletedElements.Remove(element);
        }

        private static void PrintMinimum()
        {
            var element = _elements[0];
            while (_deletedElements.ContainsKey(element))
            {
                Pop();
                _deletedElements.Remove(element);
                element = _elements[0];
            }
            Console.WriteLine(element);
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
