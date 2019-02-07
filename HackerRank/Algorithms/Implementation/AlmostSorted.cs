using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/almost-sorted/problem
    /// Difficulty : Medium
    /// Solution : Although the below code passes all test cases, it is probably the ugliest code piece on this repository.
    /// Maybe I will rewrite it sometime when my cold passes.
    /// </summary>
    public static class AlmostSorted
    {
        public static void Solve()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            almostSorted(arr);
        }

        private static void almostSorted(int[] arr)
        {
            var sortedArr = new int[arr.Length];
            Array.Copy(arr, sortedArr, arr.Length);
            Array.Sort(sortedArr);
            var possibleReverseBegin = 0;
            var possibleReverseEnd = 0;
            var foundReverse = false;
            var reverseImpossible = false;
            var foundSwap = false;
            var swapImpossible = false;
            var swapFirstIndex = -1;
            var swapSecondIndex = -1;

            if (arr[0] != sortedArr[0])
            {
                foundSwap = true;
                swapFirstIndex = 0;
            }

            for (int i = 1; i < arr.Length; i++)
            {
                if (!swapImpossible && arr[i] != sortedArr[i])
                {
                    foundSwap = true;
                    if (swapSecondIndex != -1)
                    {
                        swapImpossible = true;
                    }
                    else if (swapFirstIndex == -1)
                    {
                        swapFirstIndex = i;
                    }
                    else
                    {
                        swapSecondIndex = i;
                    }
                }
                if (arr[i] > arr[i - 1])
                    continue;
                else
                {
                    if (foundReverse)
                    {
                        reverseImpossible = true;
                        continue;
                    }
                    foundReverse = true;
                    possibleReverseBegin = i - 1;
                    
                    while (true)
                    {
                        if (i == arr.Length - 1)
                        {
                            possibleReverseEnd = arr.Length - 1;
                            break;
                        }

                        if (arr[i + 1] < arr[i])
                        {
                            i++;
                        }
                        else
                        {
                            possibleReverseEnd = i;
                            break;
                        }
                    }
                }
            }

            if (!swapImpossible && foundSwap && possibleReverseEnd - possibleReverseBegin < 2)
            {
                Console.WriteLine("yes");
                Console.WriteLine($"swap {swapFirstIndex + 1} {swapSecondIndex + 1}");
                return;
            }

            if (!reverseImpossible && foundReverse)
            {
                if ((possibleReverseBegin == 0 || arr[possibleReverseEnd] > arr[possibleReverseBegin - 1]) && 
                    (possibleReverseEnd == arr.Length - 1 || arr[possibleReverseEnd + 1] > arr[possibleReverseBegin]))
                {
                    Console.WriteLine("yes");
                    Console.WriteLine($"reverse {possibleReverseBegin + 1} {possibleReverseEnd + 1}");
                    return;
                }
            }
            
            if(foundSwap || foundReverse)
                Console.WriteLine("no");
            else
                Console.WriteLine("yes");
        }
    }

}
