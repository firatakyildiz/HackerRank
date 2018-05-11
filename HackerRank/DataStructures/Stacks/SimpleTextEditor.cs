using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructures.Stacks
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/simple-text-editor/problem
    /// Difficulty : Medium
    /// </summary>
    public class SimpleTextEditor
    {
        public static void Solve()
        {
            var numberOfOperations = Convert.ToInt32(Console.ReadLine());
            var builder = new StringBuilder();
            var stack = new Stack<Operation>();
            for (var i = 0; i < numberOfOperations; i++)
            {
                var arr = Console.ReadLine().Split();
                switch (arr[0])
                {
                    case "1":
                        stack.Push(new Operation { OperationType = OperationType.Delete, Value = arr[1].Length.ToString() });
                        builder.Append(arr[1]);
                        break;
                    case "2":
                        var val = Convert.ToInt32(arr[1]);
                        var len = builder.Length;
                        stack.Push(new Operation{ OperationType = OperationType.Append, Value = builder.ToString().Substring(len - val, val) });
                        builder.Remove(len - val, val);
                        break;
                    case "3":
                        Console.WriteLine(builder[Convert.ToInt32(arr[1]) - 1]);
                        break;
                    case "4":
                        var op = stack.Pop();
                        if (op.OperationType == OperationType.Append)
                        {
                            builder.Append(op.Value);
                        }
                        else
                        {
                            var length = Convert.ToInt32(op.Value);
                            builder.Remove(builder.Length - length, length);
                        }
                        break;
                }
            }
        }

        class Operation
        {
            public OperationType OperationType { get; set; }
            public string Value { get; set; }
        }

        enum OperationType
        {
            Append, Delete
        }
    }
}
