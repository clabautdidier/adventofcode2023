using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2023.day6
{
    public class Solver
    {
        public long Part1(string[] lines)  
        {
            int[] times = parseNumbers(lines[0]);
            int[] distances = parseNumbers(lines[1]);

            long result = 1;
            for (int i=0; i<times.Length; i++)
            {
                int count = 0;
                int time = times[i];
                int distance = distances[i];

                for (int hold=1; hold<time-1; hold++)
                {
                    if (hold * (time - hold) > distance) count++;
                }

                result *= count;
            }

            return result;
        }

        private int[] parseNumbers(string line)
        {
            string l = line.Substring(10);
            while (l.Contains("  ")) { l = l.Replace("  ", " "); }
            string[] parts = l.Trim().Split(" ");

            return parts.ToList().ConvertAll(part => int.Parse(part)).ToArray();
        }

        public long Part2(string[] lines)
        {
            long times = long.Parse(lines[0][10..].Replace(" ", ""));
            long distances = long.Parse(lines[1][10..].Replace(" ", ""));

            long result = 1;
            long count = 0;
            long hold = 0;
            long start = times/2;

            while (hold < start)
            {
                long distanceAfterHold = (start - hold) * (times - (start - hold));
                long distanceAfterHold2 = (start + hold) * (times - (start + hold));
                //Console.WriteLine(hold + " = " + distanceAfterHold + " (" + count + ")");

                if (distanceAfterHold > distances) count++;
                if (distanceAfterHold2 > distances) count++;

                if (distanceAfterHold < distances) break;
                hold++;
            }

            //for (long hold = 1; hold < times - 1; hold++)
            //{
            //    long distanceAfterHold = hold * (times - hold);
            //    Console.WriteLine(hold + " = " + distanceAfterHold + " (" + count + ")");
            //    //if (distanceAfterHold < previousDistance) break;

            //    if (distanceAfterHold > distances) count++;
            //}

            result *= count;

            return result-1;
        }

    }
}
