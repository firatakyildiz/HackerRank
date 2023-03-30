using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.InterviewPreparationKit.DictionariesAndHashmaps
{
    /// <summary>
    /// Keep individual number frequencies in a hashtable. Keep numbers grouped by frequency in another hashtable.
    /// </summary>
    class Solution
    {
        private static Dictionary<int, List<int>> frequencyGroups = new Dictionary<int, List<int>>();
        private static Dictionary<int, int> individualFrequencies = new Dictionary<int, int>();

        private static void changeFrequency(int input, int oldFrequency, int newFrequency)
        {
            individualFrequencies[input] = newFrequency;
            if(oldFrequency != 0)
                frequencyGroups[oldFrequency].Remove(input);
            if (!frequencyGroups.ContainsKey(newFrequency))
                frequencyGroups[newFrequency] = new List<int>();
            frequencyGroups[newFrequency].Add(input);
        }
        private static void insert(int input)
        {
            if (individualFrequencies.ContainsKey(input))
            {
                var previousFrequency = individualFrequencies[input];
                var newFrequency = previousFrequency + 1;
                changeFrequency(input, previousFrequency, newFrequency);
            }
            else
            {
                changeFrequency(input, 0, 1);
            }
        }

        private static void remove(int input)
        {
            if (individualFrequencies.ContainsKey(input))
            {
                var frequency = individualFrequencies[input];
                if(frequency > 1)
                    changeFrequency(input, frequency, frequency - 1);
                else
                {
                    individualFrequencies.Remove(input);
                    frequencyGroups[frequency].Remove(input);
                }
            }
        }

        private static bool check(int input)
        {
            if (frequencyGroups.ContainsKey(input))
                return frequencyGroups[input].Count > 0;
            return false;
        }

        // Complete the freqQuery function below.
        static List<int> freqQuery(List<List<int>> queries)
        {
            var result = new List<int>();
            foreach (var query in queries)
            {
                var operation = query[0];
                var value = query[1];
                
                switch (operation)
                {
                    case 1:
                        insert(value);
                        break;
                    case 2:
                        remove(value);
                        break;
                    case 3:
                        result.Add(check(value) ? 1 : 0);
                        break;
                }
            }
            return result;
        }
    }
}
