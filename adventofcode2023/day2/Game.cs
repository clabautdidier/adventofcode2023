using adventofcode2023.day2;

namespace adventofcode2023.day2
{
    internal class Game
    {
        public int id {
            get;
        }
        private List<List<int>> cubes = new List<List<int>>() { };

        public Game(string line)
        {
            string[] parts = line.Split(new char[] { ':' });
            id = int.Parse(parts[0].Split(new char[] {' '})[1]);
            string[] handful = parts[1].Split(new char[] {';'});

            int idx = 0;
            while (idx < handful.Length)
            {
                string[] cubesText = handful[idx].Split(new char[] {','});
                int red=0;
                int green=0;
                int blue=0;

                foreach (string cubeTextPart in cubesText) 
                {
                    string[] cubeText = cubeTextPart.Trim().Split(' ');
                    string cubeColour = cubeText[1];
                    int cubeCount = int.Parse(cubeText[0]);

                    if (cubeColour.Equals("red")) red += cubeCount;
                    if (cubeColour.Equals("green")) green += cubeCount;
                    if (cubeColour.Equals("blue")) blue += cubeCount;
                }

                cubes.Add(new List<int> { red, green, blue });

                idx++;
            }
            //Console.Write(line + " = ");
            //foreach (List<int> hand in cubes)
            //{
            //    Console.Write("red: " + hand[0] + ", green: " + hand[1] + ", blue: " + hand[2] + " | ");
            //}
            //Console.WriteLine();
        }

        internal int idIfGameIsPossible(int totalRed, int totalGreen, int totalBlue)
        {
            int myRed = cubes.ConvertAll(set => set[0]).Max();
            int myGreen = cubes.ConvertAll(set => set[1]).Max();
            int myBlue = cubes.ConvertAll(set => set[2]).Max();

            Console.Write(id + " = " + myRed + ":" + myGreen + ":" + myBlue + " || ");
            //foreach (List<int> hand in cubes)
            //{
            //    Console.Write("red: " + hand[0] + ", green: " + hand[1] + ", blue: " + hand[2] + " | ");
            //}
            Console.WriteLine(" ==> " + (myRed <= totalRed && myGreen <= totalGreen && myBlue <= totalBlue ? id : 0));

            return myRed <= totalRed && myGreen <= totalGreen && myBlue <= totalBlue ? id : 0;
        }

        internal int power()
        {
            int myRed = cubes.ConvertAll(set => set[0]).Max();
            int myGreen = cubes.ConvertAll(set => set[1]).Max();
            int myBlue = cubes.ConvertAll(set => set[2]).Max();
            return myRed*myGreen*myBlue;
        }
    }
}

