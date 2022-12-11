using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit.Day7
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/one-week-preparation-kit-no-prefix-set/problem
    /// Difficulty : Hard
    /// Solution : Keep incoming words as a prefix tree, so that they can be checked against other words
    /// for being a prefix.
    /// </summary>
    internal class NoPrefixSet
    {
        public static void Solve()
        {
            var numberOfWords = Convert.ToInt32(Console.ReadLine().Trim());

            var words = new List<string>();

            for (var i = 0; i < numberOfWords; i++)
            {
                var wordsItem = Console.ReadLine();
                words.Add(wordsItem);
            }

            noPrefix(words);
        }

        private class Node
        {
            public char c;
            public List<Node> children = new();
        }

        public static void noPrefix(List<string> words)
        {
            var list = new List<Node>();
            AddWord(words[0], list);
            for (var i = 1; i < words.Count; i++)
            {
                // check if this word conflicts with some other
                if (IsPrefix(words[i], list))
                {
                    Console.WriteLine("BAD SET");
                    Console.WriteLine(words[i]);
                    return;
                }

                AddWord(words[i], list);
            }

            Console.WriteLine("GOOD SET");
        }

        private static void AddWord(string word, List<Node> list)
        {
            var currentList = list;
            foreach (var c in word)
            {
                var existingNode = currentList.FirstOrDefault(x => x.c == c);
                if (existingNode != null)
                {
                    currentList = existingNode.children;
                }
                else
                {
                    var newNode = new Node { c = c };
                    currentList.Add(newNode);
                    currentList = newNode.children;
                }
            }
        }

        private static bool IsPrefix(string s, List<Node> list)
        {
            var currentList = list;
            foreach (var c in s)
            {
                // this is leaf, so the current word is the prefix of incoming input
                if (currentList.Count == 0)
                    return true;
                var existingNode = currentList.FirstOrDefault(x => x.c == c);
                if (existingNode == null)
                    return false;
                currentList = existingNode.children;
            }
            return true;
        }
    }
}
