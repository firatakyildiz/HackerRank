using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit.Day6
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/one-week-preparation-kit-jesse-and-cookies/problem
    /// Difficulty : Medium
    /// Explanation : Insert all cookies into a min heap. Pop elements, do the calculation and push
    /// new elements until popped element is greater than threshold value.
    /// </summary>
    internal class JesseAndCookies
    {
        public static int cookies(int k, List<int> list)
        {
            var heap = new MinHeap(list.Count);
            foreach (var cookie in list)
            {
                heap.Add(cookie);
            }

            var iterationCount = 0;
            while (true)
            {
                if (heap._size < 2 && heap.Peek() < k)
                {
                    iterationCount = -1;
                    break;
                }

                var first = heap.Pop();
                if (first >= k)
                    break;

                var second = heap.Pop();
                var newCookie = first + 2 * second;
                heap.Add(newCookie);
                iterationCount++;
            }
            return iterationCount;
        }

        public static void Solve()
        {
            var input = File.ReadAllLines("input.txt");
            var firstLine = Array.ConvertAll(input[0].Split(' '), int.Parse);
            var secondLine = Array.ConvertAll(input[1].Split(' '), int.Parse);
            Console.WriteLine(cookies(firstLine[1], secondLine.ToList()));
        }

        public class MinHeap
        {
            private readonly int[] _elements;
            public int _size;

            public MinHeap(int size)
            {
                _elements = new int[size];
            }

            private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
            private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
            private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

            private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _size;
            private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _size;
            private bool IsRoot(int elementIndex) => elementIndex == 0;

            private int GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
            private int GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
            private int GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

            private void Swap(int firstIndex, int secondIndex)
            {
                var temp = _elements[firstIndex];
                _elements[firstIndex] = _elements[secondIndex];
                _elements[secondIndex] = temp;
            }

            public bool IsEmpty()
            {
                return _size == 0;
            }

            public int Peek()
            {
                if (_size == 0)
                    throw new IndexOutOfRangeException();

                return _elements[0];
            }

            public int Pop()
            {
                if (_size == 0)
                    throw new IndexOutOfRangeException();

                var result = _elements[0];
                _elements[0] = _elements[_size - 1];
                _size--;

                ReCalculateDown();

                return result;
            }

            public void Add(int element)
            {
                if (_size == _elements.Length)
                    throw new IndexOutOfRangeException();

                _elements[_size] = element;
                _size++;

                ReCalculateUp();
            }

            private void ReCalculateDown()
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

            private void ReCalculateUp()
            {
                var index = _size - 1;
                while (!IsRoot(index) && _elements[index] < GetParent(index))
                {
                    var parentIndex = GetParentIndex(index);
                    Swap(parentIndex, index);
                    index = parentIndex;
                }
            }
        }

    }
}
