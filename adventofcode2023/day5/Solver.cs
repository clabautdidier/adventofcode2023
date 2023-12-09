using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2023.day5
{
    public class Solver
    {
        public long Part1(string[] lines)
        {
            MapCollection mapCollection = parseMapCollection(lines);

            //Console.WriteLine(mapCollection.ToString());

            String[] seeds = lines[0].Split(' ');
            long shortestLocation = long.MaxValue;
            for (int i = 1; i < seeds.Length; i++)
            {
                long location = mapCollection.getLocationForSeed(long.Parse(seeds[i]));
                if (location < shortestLocation) shortestLocation = location;
            }
            return shortestLocation;
        }

        private static MapCollection parseMapCollection(string[] lines)
        {
            MapCollection mapCollection = new MapCollection();
            Mapping mapping = new Mapping(lines[2]);
            for (int i = 3; i < lines.Length; i++)
            {
                if (lines[i].Length == 0)
                {
                    mapCollection.Add(mapping);
                    if (i < lines.Length - 1)
                    {
                        mapping = new Mapping(lines[i + 1]);
                        i++;
                    }
                }
                else
                {
                    mapping.addRange(lines[i].Split(' ').ToList().ConvertAll(s => long.Parse(s)).ToArray());
                }
            }
            mapCollection.Add(mapping);

            return mapCollection;
        }

        public long Part2(string[] lines)
        {
            MapCollection mapCollection = parseMapCollection(lines);

            String[] seeds = lines[0].Split(' ');
            long shortestLocation = long.MaxValue;
            for (int i = 1; i < seeds.Length; i += 2)
            {
                long seedIdStart = long.Parse(seeds[i]);
                long seedIdsFromStart = long.Parse(seeds[i + 1]);

                List<long[]> locations = mapCollection.applyMappingsToSeedRange(seedIdStart, seedIdStart+seedIdsFromStart);
                long shortest = locations.ConvertAll(l => l[0]).Min();

                if (shortest < shortestLocation) shortestLocation = shortest;
            }

            return shortestLocation;
        }

    }
}
