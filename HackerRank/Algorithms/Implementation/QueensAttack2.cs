using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/queens-attack-2/problem
    /// Difficulty : Medium
    /// Solution : For each of the 8 directions, find the distance that it can move if the board was empty.
    /// Then for each obstacle, determine the direction it stands according to the queen. Calculate the distance,
    /// and keep the minimum. If there are no obstacles for a direction, use the value found for empty board.
    /// </summary>
    public static class QueensAttack2
    {
        public static void Solve() {
            string[] nk = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nk[0]);
            int k = Convert.ToInt32(nk[1]);
            string[] r_qC_q = Console.ReadLine().Split(' ');
            int r_q = Convert.ToInt32(r_qC_q[0]);
            int c_q = Convert.ToInt32(r_qC_q[1]);
            int[][] obstacles = new int[k][];
            for (int i = 0; i < k; i++)
            {
                obstacles[i] = Array.ConvertAll(Console.ReadLine().Split(' '), obstaclesTemp => Convert.ToInt32(obstaclesTemp));
            }
            int result = queensAttack(n, k, r_q, c_q, obstacles);
            Console.WriteLine(result);
        }

        private static int queensAttack(int sizeOfBoard, int numberOfObstacles,int startRow, int startColumn, int[][] obstacles)
        {
            var distances = new Dictionary<Direction, int>()
            {
                [Direction.North] =  getNumberOfReachableSquaresInEmptyBoard(startRow, startColumn, sizeOfBoard, Direction.North),
                [Direction.South] = getNumberOfReachableSquaresInEmptyBoard(startRow, startColumn, sizeOfBoard, Direction.South),
                [Direction.East] = getNumberOfReachableSquaresInEmptyBoard(startRow, startColumn, sizeOfBoard, Direction.East),
                [Direction.West] = getNumberOfReachableSquaresInEmptyBoard(startRow, startColumn, sizeOfBoard, Direction.West),
                [Direction.NorthEast] = getNumberOfReachableSquaresInEmptyBoard(startRow, startColumn, sizeOfBoard, Direction.NorthEast),
                [Direction.NorthWest] = getNumberOfReachableSquaresInEmptyBoard(startRow, startColumn, sizeOfBoard, Direction.NorthWest),
                [Direction.SouthEast] = getNumberOfReachableSquaresInEmptyBoard(startRow, startColumn, sizeOfBoard, Direction.SouthEast),
                [Direction.SouthWest] = getNumberOfReachableSquaresInEmptyBoard(startRow, startColumn, sizeOfBoard, Direction.SouthWest)
            };

            foreach (var obstacle in obstacles)
            {
                var direction = GetDirection(startRow, startColumn, obstacle[0], obstacle[1]);
                if (direction == Direction.Irrelevant)
                    continue;
                var distance = getNumberOfReachableSquaresForOneDirection(startRow, startColumn, obstacle[0], obstacle[1], direction);
                if (distance < distances[direction])
                    distances[direction] = distance;
            }
            return distances.Sum(x => x.Value);
        }

        private static int getNumberOfReachableSquaresInEmptyBoard(int rowNumber, int columnNumber, int sizeOfBoard, Direction direction)
        {
            var distance = int.MaxValue;
            switch (direction)
            {
                case Direction.West:
                    distance = columnNumber - 1;
                    break;
                case Direction.North:
                    distance = sizeOfBoard - rowNumber;
                    break;
                case Direction.South:
                    distance = rowNumber - 1;
                    break;
                case Direction.East:
                    distance = sizeOfBoard - columnNumber;
                    break;
                case Direction.NorthEast:
                    distance = Math.Min(sizeOfBoard - rowNumber, sizeOfBoard - columnNumber);
                    break;
                case Direction.NorthWest:
                    distance = Math.Min(sizeOfBoard - rowNumber, columnNumber - 1);
                    break;
                case Direction.SouthEast:
                    distance = Math.Min(rowNumber - 1, sizeOfBoard - columnNumber);
                    break;
                case Direction.SouthWest:
                    distance = Math.Min(rowNumber - 1, columnNumber - 1);
                    break;
            }
            return distance;
        }

        private static Direction GetDirection(int startRow, int startColumn, int endRow, int endColumn)
        {
            var horizontalDistance = endColumn - startColumn;
            var verticalDistance = endRow - startRow;
            if (verticalDistance == 0)
            {
                return endColumn > startColumn? Direction.East : Direction.West;
            }
            if (horizontalDistance == 0)
            {
                return endRow > startRow ? Direction.North : Direction.South;
            }
            if (horizontalDistance == verticalDistance)
            {
                return endColumn > startColumn ? Direction.NorthEast : Direction.SouthWest;
            }
            if (horizontalDistance == -verticalDistance)
            {
                return endColumn > startColumn ? Direction.SouthEast : Direction.NorthWest;
            }
            return Direction.Irrelevant;
        }

        private static int getNumberOfReachableSquaresForOneDirection(int startRow, int startColumn, int endRow, int endColumn,  Direction direction)
        {
            var distance = 0;
            switch (direction)
            {
                case Direction.North:
                    distance = endRow - startRow;
                    break;
                case Direction.South:
                    distance =  startRow - endRow;
                    break;
                case Direction.East:
                case Direction.NorthEast:
                case Direction.SouthEast:
                    distance = endColumn - startColumn;
                    break;
                case Direction.West:
                case Direction.NorthWest:
                case Direction.SouthWest:
                    distance = startColumn - endColumn;
                    break;
                default:
                case Direction.Irrelevant:
                    distance = int.MaxValue;
                    break;
            }
            return distance - 1;
        }

        private enum Direction
        {
            North,
            South,
            East,
            West,
            NorthEast,
            NorthWest,
            SouthEast,
            SouthWest,
            Irrelevant
        }
    }
}
