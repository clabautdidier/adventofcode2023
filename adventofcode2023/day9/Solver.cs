using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2023.day9
{
    public class Solver
    {
        public long Part1(string[] lines)  
        {
            return lines.ToList()
                .ConvertAll(line => line.Split(' '))
                .ConvertAll(parts => parts.ToList().ConvertAll(part => long.Parse(part)))
                .ConvertAll(parts => FindNextNumber(parts))
                .Sum();
        }

        public long Part2(string[] lines)
        {
            return lines.ToList()
                .ConvertAll(line => line.Split(' '))
                .ConvertAll(parts => parts.ToList().ConvertAll(part => long.Parse(part)))
                .ConvertAll(parts => FindPreviousNumber(parts))
                .Sum();
        }

        private long FindPreviousNumber(List<long> parts)
        {
            List<List<long>> deltas = calculateDeltas(parts);
            return calculatePreviousNumber(deltas);
        }

        private long calculatePreviousNumber(List<List<long>> deltas)
        {
            long sum = 0;
            for (int i=deltas.Count-2; i>=0; i--)
            {
                //Console.WriteLine(deltas[i][0] + " - " + sum);
                sum = deltas[i][0] - sum;
            }
            //Console.WriteLine(sum);
            return sum;
            //return deltas.ConvertAll(d => d.First()).Aggregate((n1, n2) => {
            //    Console.WriteLine(n1 + "+" + n2);
            //    return n1 + n2;
            //});
        }

        private long FindNextNumber(List<long> parts)
        {
            List<List<long>> deltas = calculateDeltas(parts);
            return calculateNextNumber(deltas);
        }

        private long calculateNextNumber(List<List<long>> deltas)
        {
            return deltas.ConvertAll(d => d.Last()).Sum();
        }

        private List<List<long>> calculateDeltas(List<long> parts)
        {
            List<List<long>> deltas = new List<List<long>>();
            deltas.Add(parts);

            while (!AllZeroes(deltas.Last()))
            {
                deltas.Add(calculateNextDeltas(deltas.Last()));
            }

            return deltas;
        }

        private List<long> calculateNextDeltas(List<long> list)
        {
            List<long> nextDeltas = new List<long>();

            for (int i=0; i<list.Count-1; i++)
            {
                nextDeltas.Add(list[i + 1] - list[i]);
            }

            return nextDeltas;
        }

        private bool AllZeroes(List<long> list)
        {
            return list.All(x => x == 0);
        }


    }
}
