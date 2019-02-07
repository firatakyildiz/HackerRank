using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/two-pluses/problem
    /// Difficulty : Medium
    /// Solution : Find all possible pluses, compare them for overlapping,
    /// calculate all (most) the possible areas and return greatest. 
    /// </summary>
    public static class TwoPluses
    {
        public static void Solve()
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nm[0]);
            int m = Convert.ToInt32(nm[1]);
            string[] grid = new string[n];
            for (int i = 0; i < n; i++)
            {
                string gridItem = Console.ReadLine();
                grid[i] = gridItem;
            }
            int result = twoPluses(grid);
            Console.WriteLine(result);
        }

        private static int twoPluses(string[] grid)
        {
            const int maxSize = 9;
            var possibles = new List<Tuple<int, int>>[maxSize];
            for (int i = 0; i < maxSize; i++)
            {
                possibles[i] = new List<Tuple<int, int>>();
            }
            for (var rowIndex = 0; rowIndex < grid.Length; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < grid[rowIndex].Length; columnIndex++)
                {
                    var maxPossiblePlusSize = getMaxPossiblePlusSize(grid, rowIndex, columnIndex);
                    if (maxPossiblePlusSize != 0)
                    {
                        possibles[maxPossiblePlusSize].Add(new Tuple<int, int>(rowIndex, columnIndex));
                    }
                }
            }

            // it seems i did not realized that for any center point where a plus with size N can be put,
            // there can also be pluses in the range [1,N)
            for (int i = maxSize - 1; i > 1; i--)
            {
                for (int j = 0; j < possibles[i].Count; j++)
                {
                    possibles[i - 1].Add(possibles[i][j]);
                }
            }

            var globalMaximumArea = 0;
            for (int i = maxSize - 1; i >= 0; i--)
            {
                for (int j = 0; j < possibles[i].Count; j++)
                {
                    var firstSize = i;
                    var firstPlusLocation = possibles[i][j];
                    for (var secondRowIndex = i; secondRowIndex >= 0; secondRowIndex--)
                    {
                        // a little optimization, if the calculated result can not be greater
                        // than our previous best, do not bother
                        if(calculateArea(firstSize, secondRowIndex) < globalMaximumArea)
                            continue;
                        for (var secondColumnIndex = 0; secondColumnIndex < possibles[secondRowIndex].Count; secondColumnIndex++)
                        {
                            var secondSize = secondRowIndex;
                            var secondPlusLocation = possibles[secondRowIndex][secondColumnIndex];
                            if (doPlusesOverlap(firstSize, firstPlusLocation, secondSize, secondPlusLocation))
                                continue;
                            var currentAreaMultiplication = calculateArea(firstSize, secondSize);
                            if (currentAreaMultiplication > globalMaximumArea)
                            {
                                globalMaximumArea = currentAreaMultiplication;

                            }
                        }
                    }
                }
            }
            return globalMaximumArea;
        }

        private static bool doPlusesOverlap(int firstSize, Tuple<int, int> firstPlusLocation, int secondSize, Tuple<int, int> secondPlusLocation)
        {
            var firstPlus = new List<Tuple<int, int>>(){firstPlusLocation};
            var secondPlus = new List<Tuple<int, int>>(){secondPlusLocation};
            for (var i = 1; i < firstSize; i++)
            {
                firstPlus.Add(new Tuple<int, int>(firstPlusLocation.Item1 + i, firstPlusLocation.Item2));
                firstPlus.Add(new Tuple<int, int>(firstPlusLocation.Item1 - i, firstPlusLocation.Item2));
                firstPlus.Add(new Tuple<int, int>(firstPlusLocation.Item1, firstPlusLocation.Item2 + i));
                firstPlus.Add(new Tuple<int, int>(firstPlusLocation.Item1, firstPlusLocation.Item2 - i));
            }

            for (var i = 1; i < secondSize; i++)
            {
                secondPlus.Add(new Tuple<int, int>(secondPlusLocation.Item1 + i, secondPlusLocation.Item2));
                secondPlus.Add(new Tuple<int, int>(secondPlusLocation.Item1 - i, secondPlusLocation.Item2));
                secondPlus.Add(new Tuple<int, int>(secondPlusLocation.Item1, secondPlusLocation.Item2 + i));
                secondPlus.Add(new Tuple<int, int>(secondPlusLocation.Item1, secondPlusLocation.Item2 - i));
            }

            return firstPlus.Intersect(secondPlus).Any();
        }

        private static int getMaxPossiblePlusSize(string[] grid, int rowIndex, int columnIndex)
        {
            const char goodCharacter = 'G';
            var currentSize = 0;
            if (grid[rowIndex][columnIndex] != goodCharacter)
                return currentSize;
            currentSize++;
            while (true)
            {
                if (rowIndex - currentSize < 0 || grid[rowIndex - currentSize][columnIndex] != goodCharacter ||
                    rowIndex + currentSize >= grid.Length || grid[rowIndex + currentSize][columnIndex] != goodCharacter ||
                    columnIndex - currentSize < 0 || grid[rowIndex][columnIndex - currentSize] != goodCharacter ||
                    columnIndex + currentSize >= grid[rowIndex].Length || grid[rowIndex][columnIndex + currentSize] != goodCharacter)
                    break;
                currentSize++;
            }
            return currentSize;
        }

        private static int calculateArea(int firstSize, int secondSize)
        {
            return (1 + (firstSize - 1) * 4) * (1 + (secondSize - 1) * 4);
        }
    }
}
