using System.ComponentModel;

namespace adventofcode2023.day7
{
    internal class HandComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            long strengthX = calculateStrength(x);
            long strengthY = calculateStrength(y);

            return strengthX > strengthY ? 1 : -1;
        }

        private long calculateStrength(string? hand)
        {
            string hexString = mapToHandType(hand) + mapToHex(hand);
            return long.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
        }

        private string mapToHandType(string? hand)
        {
            Dictionary<char, int> handMap = MapToDictionary(hand);

            if (isFiveOfAKind(handMap)) { return "6"; }
            if (IsFourOfAKind(handMap)) { return "5"; }
            if (IsFullHouse(handMap)) { return "4"; }
            if (IsThreeOfAKind(handMap)) { return "3"; }
            if (IsTwoPair(handMap)) { return "2"; }
            if (IsOnePair(handMap)) { return "1"; }

            return "0";
        }

        private bool IsOnePair(Dictionary<char, int> handMap)
        {
            if (handMap.Count != 4) return false;

            char[] keys = handMap.Keys.ToArray();
            int pairs = 0;
            if (handMap[keys[0]] == 2) pairs++;
            if (handMap[keys[1]] == 2) pairs++;
            if (handMap[keys[2]] == 2) pairs++;
            if (handMap[keys[3]] == 2) pairs++;

            return pairs == 1;
        }

        private bool IsTwoPair(Dictionary<char, int> handMap)
        {
            if (handMap.Count != 3) return false;

            char[] keys = handMap.Keys.ToArray();
            int pairs = 0;
            if (handMap[keys[0]] == 2) pairs++;
            if (handMap[keys[1]] == 2) pairs++;
            if (handMap[keys[2]] == 2) pairs++;

            return pairs == 2;
        }

        private bool IsThreeOfAKind(Dictionary<char, int> handMap)
        {
            char[] keys = handMap.Keys.ToArray();
            return handMap.Count < 4 && (handMap[keys[0]] == 3 || handMap[keys[1]] == 3 || handMap[keys[2]] == 3);
        }

        private bool IsFullHouse(Dictionary<char, int> handMap)
        {
            char[] keys = handMap.Keys.ToArray();
            return handMap.Count == 2 && (handMap[keys[0]] == 2 || handMap[keys[1]] == 2);
        }

        private Dictionary<char, int> MapToDictionary(string? hand)
        {
            Dictionary<char, int> handMap = new Dictionary<char, int>();
            foreach (char c in hand)
            {
                if (!handMap.ContainsKey(c))
                {
                    handMap.Add(c, 1);
                }
                else
                {
                    handMap[c]++;
                }
            }
            return handMap;
        }

        private bool IsFourOfAKind(Dictionary<char, int> handMap)
        {
            char[] keys = handMap.Keys.ToArray();
            return handMap.Count == 2 && (handMap[keys[0]] == 4 || handMap[keys[1]] == 4);
        }

        private bool isFiveOfAKind(Dictionary<char, int> handMap)
        {
            char[] keys = handMap.Keys.ToArray();
            return handMap.Count == 1 && handMap[keys[0]] == 5;
        }

        private string mapToHex(string? hand)
        {
            string result = "";
            for (int i=0; i<hand.Length; i++)
            {
                char ch = hand[i];
                switch (ch)
                {
                    case 'T': result += 'A'; break;
                    case 'J': result += 'B'; break;
                    case 'Q': result += 'C'; break;
                    case 'K': result += 'D'; break;
                    case 'A': result += 'E'; break;
                    default: result += ch; break;
                }
            }
            return result;
        }
    }
}