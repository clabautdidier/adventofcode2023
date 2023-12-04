using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2023.day2
{
    public class Solver
    {
        public int Part1(string[] lines)  
        {
            List<Game> games = new List<Game>();
            foreach (String line in lines)
            {
                games.Add(new Game(line));
            }
            return games.ConvertAll(game => game.idIfGameIsPossible(12, 13, 14)).Sum();
        }

        public int Part2(String[] lines)
        {
            List<Game> games = new List<Game>();
            foreach (String line in lines)
            {
                games.Add(new Game(line));
            }
            return games.ConvertAll(game => game.power()).Sum();
        }

    }
}
