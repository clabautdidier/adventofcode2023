﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2023.day8
{
    public class Solver
    {
        public long Part1(string[] lines)  
        {
            Dictionary<string, string[]> network = parseNetwork(lines);
            int steps = 0;
            int directionPos = 0;
            string directions = lines[0];
            string currentKey = "AAA";

            while (!currentKey.Equals("ZZZ"))
            {
                steps++;
                int nextKeyPos = directions[directionPos] == 'L' ? 0 : 1;
                currentKey = network[currentKey][nextKeyPos];
                directionPos++;
                if (directionPos >= directions.Length) directionPos = 0;
            }

            return steps;
        }

        private Dictionary<string, string[]> parseNetwork(string[] lines)
        {
            Dictionary<string, string[]> network = new();
            for (int i=2; i<lines.Length; i++)
            {
                string[] parts = lines[i].Replace(" ", "").Replace("(", "").Replace(")", "").Split(new char[] { '=', ',' });
                network.Add(parts[0], new string[] { parts[1], parts[2] });
            }
            return network;
        }

        public long Part2(string[] lines)  
        {
            Dictionary<string, string[]> network = parseNetwork(lines);
            int steps = 0;
            int directionPos = 0;
            string directions = lines[0];

            List<string> keys = network.Keys.ToList().FindAll(key => key.EndsWith("A"));

            int numberOfPaths = keys.Count;
            List<int> stepsForKey = new();

            while (keys.Count > 0 && steps < 50000)
            {
                keys.FindAll(key => key.EndsWith('Z')).ForEach(key => stepsForKey.Add(steps));
                steps++;
                int nextKeyPos = directions[directionPos] == 'L' ? 0 : 1;
                keys = keys.FindAll(key => !key.EndsWith('Z')).ConvertAll(key => network[key][nextKeyPos]);
                directionPos++;
                if (directionPos >= directions.Length) directionPos = 0;
            }

            return lcm_of_array_elements(stepsForKey.ToArray());
        }

        public static long lcm_of_array_elements(int[] element_array)
        {
            long lcm_of_array_elements = 1;
            int divisor = 2;

            while (true)
            {

                int counter = 0;
                bool divisible = false;
                for (int i = 0; i < element_array.Length; i++)
                {

                    // lcm_of_array_elements (n1, n2, ... 0) = 0.
                    // For negative number we convert into
                    // positive and calculate lcm_of_array_elements.
                    if (element_array[i] == 0)
                    {
                        return 0;
                    }
                    else if (element_array[i] < 0)
                    {
                        element_array[i] = element_array[i] * (-1);
                    }
                    if (element_array[i] == 1)
                    {
                        counter++;
                    }

                    // Divide element_array by devisor if complete
                    // division i.e. without remainder then replace
                    // number with quotient; used for find next factor
                    if (element_array[i] % divisor == 0)
                    {
                        divisible = true;
                        element_array[i] = element_array[i] / divisor;
                    }
                }

                // If divisor able to completely divide any number
                // from array multiply with lcm_of_array_elements
                // and store into lcm_of_array_elements and continue
                // to same divisor for next factor finding.
                // else increment divisor
                if (divisible)
                {
                    lcm_of_array_elements = lcm_of_array_elements * divisor;
                }
                else
                {
                    divisor++;
                }

                // Check if all element_array is 1 indicate 
                // we found all factors and terminate while loop.
                if (counter == element_array.Length)
                {
                    return lcm_of_array_elements;
                }
            }
        }
    }
}
