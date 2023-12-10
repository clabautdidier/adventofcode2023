using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2023.day7
{
    public class Solver
    {
        public long Part1(string[] lines)  
        {
            SortedDictionary<string, int> hands = parseHands(lines, new HandComparer(), false);

            long sum = 0;
            long count = 1;
            foreach (KeyValuePair<string, int> pair in hands)
            {
                sum += pair.Value * count;
                count++;
            }

            return sum;
        }

        private SortedDictionary<string, int> parseHands(string[] lines, IComparer<string> comparer, bool jokerIsOne)
        {
            Dictionary<string, int> unsortedHands = new();
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                string hand = parts[0];
                if (jokerIsOne) hand = hand.Replace('J', '1');

                unsortedHands.Add(hand, int.Parse(parts[1]));
            }

            SortedDictionary<string, int> hands = new(unsortedHands, comparer);

            return hands;
        }

        public long Part2(string[] lines)
        {
            SortedDictionary<string, int> hands = parseHands(lines, new BestHandComparer(), true);

            long sum = 0;
            long count = 1;
            foreach (KeyValuePair<string, int> pair in hands)
            {
                sum += pair.Value * count;
                count++;
            }

            return sum;
        }

    }
}
