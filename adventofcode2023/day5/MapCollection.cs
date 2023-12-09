namespace adventofcode2023.day5
{
    public class MapCollection
    {
        private List<Mapping> mappings = new List<Mapping>();

        internal void Add(Mapping mapping)
        {
            mappings.Add(mapping);
        }

        internal long getLocationForSeed(long seedNumber)
        {
            string from = "seed";
            Mapping mapping = MappingFor(from);

            long currentNumber = seedNumber;
            //Console.WriteLine(currentNumber);
            while (mapping != null)
            {
                currentNumber = mapping.map(currentNumber);
                //Console.WriteLine(currentNumber);

                string nextMapping = mapping.To;

                mapping = MappingFor(nextMapping);

                if (mapping == null && !nextMapping.Equals("location")) {
                    Console.Error.WriteLine(nextMapping + " not found!");
                    return 0;
                }
            }

            return currentNumber;
        }

        private Mapping MappingFor(string nextMapping)
        {
            foreach (Mapping mapping in mappings)
            {
                if (mapping.From.Equals(nextMapping)) return mapping;
            }
            return null;
        }

        public override string? ToString()
        {
            string result = "";
            mappings.ForEach(mapping => { result += mapping; });

            return result;
        }

        internal List<long[]> applyMappingsToSeedRange(long from, long to)
        {
            //Console.WriteLine("SeedId from " + from + " to " + to);

            List<long[]> result = new List<long[]> { new long[] { from, to } };

            foreach (Mapping mapping in mappings)
            {
                //Console.WriteLine(mapping.From + " to " + mapping.To);

                result = applyMappingToSeedRange(result, mapping);

                //foreach (long[] location in result)
                //{
                //    Console.WriteLine(location[0] + " -> " + location[1]);
                //}

                //Console.WriteLine();
            }

            return result;
        }

        private List<long[]> applyMappingToSeedRange(List<long[]> result, Mapping mapping)
        {
            List<long[]> newResult = result.ConvertAll(r => new long[] { r[0], r[1], 0 });

            foreach (long[] range in mapping.Ranges) 
            { 
                long rangeFrom = range[1];
                long rangeTo = range[1] + range[2] - 1;
                long rangeDelta = range[0] - range[1];

                //Console.WriteLine("Map " + range[1] + " -> " + (range[1] + range[2] - 1) + " = " + (range[0] - range[1]));

                newResult = applyMappingRangeToSeedLocation(newResult, rangeFrom, rangeTo, rangeDelta);
            }

            return newResult;
        }

        public List<long[]> applyMappingRangeToSeedLocation(List<long[]> currentLocations, long rangeFrom, long rangeTo, long rangeDelta)
        {
            List<long[]> newLocations = new List<long[]>();

            foreach (long[] location in currentLocations)
            {
                if (location[2] == 1 || rangeTo < location[0] || rangeFrom > location[1])
                {
                    newLocations.Add(location);
                }
                else
                {
                    if (rangeFrom > location[0])
                    {
                        newLocations.Add(new long[] { location[0], rangeFrom-1, 1 });
                    }

                    newLocations.Add(new long[] { 
                        Math.Max(location[0], rangeFrom) + rangeDelta, 
                        Math.Min(location[1], rangeTo)+rangeDelta, 
                        1 });

                    if (rangeTo < location[1])
                    {
                        newLocations.Add(new long[] { rangeTo+1, location[1], 1 });
                    }
                }
            }
            return newLocations;
        }
    }
}