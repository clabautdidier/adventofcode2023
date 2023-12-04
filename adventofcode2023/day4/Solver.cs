using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2023.day4
{
    public class Solver
    {
        public int Part1(string[] lines)  
        {
            return lines.Sum(line => cardValue(line));
        }

        private int cardValue(string line)
        {
            string[] p = line.Split(':');
            string[] parts = p[1].Split('|');
            string[] wins = parts[0].Trim().Replace("  ", " ").Split(" ");
            string[] myNumbers = parts[1].Trim().Replace("  ", " ").Split(" ");

            int cardValue = 0;
            foreach (string s in wins)
            {
                if (myNumbers.Contains(s))
                {
                    if (cardValue == 0)
                    {
                        cardValue = 1;
                    }
                    else
                    {
                        cardValue *= 2;
                    }
                }
            }

            return cardValue;
        }

        public int Part2(string[] lines)  
        {
            List<Card> cards = lines.ToList().ConvertAll(line => toCard(line));

            for (int idx=0; idx<cards.Count; idx++)
            {
                int cardValue = cards[idx].CalculateValue();
                for (int valueIdx = 0; valueIdx < cardValue && (idx+valueIdx<cards.Count); valueIdx++)
                {
                    cards[idx + valueIdx + 1].increaseCountWith(cards[idx].Count);
                }
            }

            return cards.ConvertAll(card => card.Count).Sum();
        }

        private Card toCard(string line)
        {
            string[] p = line.Split(':');
            string[] parts = p[1].Split('|');
            string[] wins = parts[0].Trim().Replace("  ", " ").Split(" ");
            string[] myNumbers = parts[1].Trim().Replace("  ", " ").Split(" ");

            return new Card(wins, myNumbers);
        }

        private class Card
        {
            private string[] wins;
            private string[] myNumbers;
            private int count = 1;

            public Card(string[] wins, string[] myNumbers)
            {
                this.wins = wins;
                this.myNumbers = myNumbers;
            }

            public int Count { get => count; set => count = value; }

            internal int CalculateValue()
            {
                int cardValue = 0;
                foreach (string s in wins)
                {
                    if (myNumbers.Contains(s))
                    {
                        cardValue++;
                    }
                }
                return cardValue;
            }

            internal void increaseCountWith(int count)
            {
                this.count += count;
            }
        }
    }
}
