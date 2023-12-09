namespace adventofcode2023.day5
{
    internal class Mapping
    {
        private readonly string from;
        private readonly string to;


        private List<long[]> ranges = new List<long[]>();

        public Mapping(string line)
        {
            string[] parts = line.Split(new char[] { ' ', '-' });
            this.from = parts[0];
            this.to = parts[2];
        }

        public string From => from;

        public string To => to;

        public List<long[]> Ranges => ranges;

        internal void addRange(long[] range)
        {
            Ranges.Add(range);
        }

        internal long map(long number)
        {
            int rangeIdx = findRangeIdx(number);

            if (rangeIdx < 0) { return number; }

            return Ranges[rangeIdx][0]+(number - Ranges[rangeIdx][1]);
        }

        private int findRangeIdx(long number)
        {
            for (int i=0; i<Ranges.Count; i++)
            {
                if (number >= Ranges[i][1] && number < Ranges[i][1] + Ranges[i][2]) return i;
            }
            return -1;
        }

        public override string? ToString()
        {
            string result = "Mapping [from " + from + ", to " + to + ", ";
            Ranges.ForEach(x => result += "[" + x[0] + "," + x[1] + "," + x[2] + "]");

            return result;
        }
    }
}