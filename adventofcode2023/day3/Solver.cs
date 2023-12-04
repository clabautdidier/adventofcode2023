using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2023.day3
{
    public class Solver
    {
        public long Part1(string[] lines)  
        {
            int y = 0;
            long sumOfNumbers = 0;

            while (y < lines.Length)
            {
                //Console.WriteLine(lines[y]);

                bool numberFound = false;
                int currentNumber = 0;
                bool symbolAdjacent = false;
                int x = 0;

                while (x < lines[y].Length)
                {
                    if (isADigit(lines[y][x]))
                    {
                        numberFound = true;
                        currentNumber = currentNumber*10 + int.Parse(lines[y][x].ToString());
                        if (hasSymbolAdjacent(lines, y, x)) symbolAdjacent = true;
                    }
                    if (!isADigit(lines[y][x]) || x == lines[y].Length-1)
                    {
                        if (numberFound)
                        {
                            //Console.WriteLine(currentNumber + "=" + symbolAdjacent);

                            if (symbolAdjacent)
                            {
                                sumOfNumbers += currentNumber;
                            }
                            symbolAdjacent = false;
                            currentNumber = 0;
                            numberFound = false;
                        }
                    }
                    x++;
                }
                y++;
            }
            return sumOfNumbers;
        }

        public long Part2(string[] lines)
        {
            long sumOfNumbers = 0;
            Dictionary<Point, List<int>> gears = new Dictionary<Point, List<int>>();

            int y;
            for (y=0; y<lines.Length; y++)
                for (int x=0; x < lines[y].Length; x++)
                {
                    if (lines[y][x] == '*') gears.Add(new Point(x, y), new List<int>());
                }
            y = 0;
            while (y < lines.Length)
            {
                //Console.WriteLine(lines[y]);

                bool numberFound = false;
                int currentNumber = 0;
                Point adjacentGear = Point.Empty;
                int x = 0;

                while (x < lines[y].Length)
                {
                    if (isADigit(lines[y][x]))
                    {
                        numberFound = true;
                        currentNumber = currentNumber * 10 + int.Parse(lines[y][x].ToString());
                        if (adjacentGear.IsEmpty) adjacentGear = findAdjacentGear(lines, y, x);
                    }
                    if (!isADigit(lines[y][x]) || x == lines[y].Length - 1)
                    {
                        if (numberFound)
                        {
                            //Console.WriteLine(currentNumber + "=" + symbolAdjacent);

                            if (!adjacentGear.IsEmpty)
                            {
                                if (!gears.ContainsKey(adjacentGear)) { gears.Add(adjacentGear, new List<int>()); }
                                gears[adjacentGear].Add(currentNumber);
                            }
                            adjacentGear = Point.Empty;
                            currentNumber = 0;
                            numberFound = false;
                        }
                    }
                    x++;
                }
                y++;
            }
            return gears.AsQueryable().Where(kv => kv.Value.Count() > 1).Select(kv => kv.Value.Aggregate((acc, val) => acc*val)).Sum();
        }

        private Point findAdjacentGear(string[] lines, int y, int x)
        {
            if (y > 0)
            {
                if (hasSymbol(lines[y - 1], x - 1, '*')) return new Point(x-1, y-1);
                if (hasSymbol(lines[y - 1], x, '*')) return new Point(x, y-1);
                if (hasSymbol(lines[y - 1], x + 1, '*')) return new Point(x+1, y-1);
            }
            if (hasSymbol(lines[y], x - 1, '*')) return new Point(x-1, y);
            if (hasSymbol(lines[y], x + 1, '*')) return new Point(x+1, y);
            if (y < lines.Length - 1)
            {
                if (hasSymbol(lines[y + 1], x - 1, '*')) return new Point(x - 1, y + 1);
                if (hasSymbol(lines[y + 1], x, '*')) return new Point(x, y + 1);
                if (hasSymbol(lines[y + 1], x + 1, '*')) return new Point(x + 1, y + 1);
            }

            return Point.Empty;
        }

        private bool hasSymbolAdjacent(string[] lines, int y, int x)
        {
            if (y > 0)
            {
                if (hasSymbol(lines[y - 1], x - 1, x + 1)) return true;
            }
            if (hasSymbol(lines[y], x - 1, x + 1)) return true;
            if (y < lines.Length-1)
            {
                if (hasSymbol(lines[y + 1], x - 1, x + 1)) return true;
            }

            return false;
        }

        private bool hasSymbol(string line, int x, char findSymbol)
        {
            if (x < 0 || x >= line.Length)
            {
                return false;
            }
            else
            {
                return line[x] == findSymbol;
            }
        }

        private bool hasSymbol(string line, int fromX, int toX)
        {
            int startX = fromX < 0 ? 0 : fromX;
            int endX = toX > line.Length-1 ? line.Length-1 : toX;

            for (int x=startX ; x <= endX; x++)
            {
                if (!isADigit(line[x]) && line[x] != '.') return true;
            }

            return false;
        }

        private bool isADigit(char v)
        {
            return v >= '0' && v <= '9';
        }


    }
}
