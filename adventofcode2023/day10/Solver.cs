using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2023.day10
{
    public class Solver
    {
        public long Part1(string[] lines)  
        {
            Point position1 = findStartingPoint(lines);
            Point position2 = position1;

            Point nextPosition1 = findNextPosition(lines, position1, position1);
            Point nextPosition2 = findNextPosition(lines, position1, nextPosition1);

            long steps = 1;

            while (!nextPosition1.Equals(nextPosition2))
            {
                steps++;
                Point previousPosition1 = position1;
                position1 = nextPosition1;
                nextPosition1 = findNextPosition(lines, position1, previousPosition1);

                Point previousPosition2 = position2;
                position2 = nextPosition2;
                nextPosition2 = findNextPosition(lines, position2, previousPosition2);
            }

            return steps;
        }

        public long Part2(string[] lines)
        {
            Point position1 = findStartingPoint(lines);
            Point currentPosition = position1;
            Point previousPosition1 = currentPosition;
            List<Point> points = new List<Point>();

            int minX = position1.X; int minY = position1.Y;
            int maxX = position1.X; int maxY = position1.Y;

            Point nextPosition1 = findNextPosition(lines, position1, position1);

            long steps = 1;

            points.Add(currentPosition);
            while (!nextPosition1.Equals(position1))
            {
                if (nextPosition1.X < minX) minX = nextPosition1.X;
                if (nextPosition1.X > maxX) maxX = nextPosition1.X;
                if (nextPosition1.Y < minY) minY = nextPosition1.Y;
                if (nextPosition1.Y > maxY) maxY = nextPosition1.Y;

                steps++;
                nextPosition1 = findNextPosition(lines, currentPosition, previousPosition1);
                previousPosition1 = currentPosition;
                currentPosition = nextPosition1;
                points.Add(nextPosition1);
            }

            int enclosed = 0;
            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    if (positionIsEnclosed(points, x, y, minX, maxX, minY, maxY)) enclosed++;
                }
            }

            return enclosed;
        }

        private bool positionIsEnclosed(List<Point> points, int x, int y, int minX, int maxX, int minY, int maxY)
        {
            if (x <= minX || x >= maxX || y <= minY || y >= maxY) return false;

            if (points.Contains(new Point(x, y))) return false;
            return contains(points, new Point(x, y));
        }

        public bool contains(List<Point> points, Point test)
        {
            int i;
            int j;
            bool result = false;
            for (i = 0, j = points.Count - 1; i < points.Count; j = i++)
            {
                if ((points[i].Y > test.Y) != (points[j].Y > test.Y) &&
                    (test.X < (points[j].X - points[i].X) * (test.Y - points[i].Y) / (points[j].Y - points[i].Y) + points[i].X))
                {
                    result = !result;
                }
            }
            return result;
        }

        private Point findNextPosition(string[] lines, Point currentPosition, Point previousPosition)
        {
            char positionChar = lines[currentPosition.Y][currentPosition.X];

            Point up = new Point(currentPosition.X, currentPosition.Y - 1);
            Point dn = new Point(currentPosition.X, currentPosition.Y + 1);
            Point lt = new Point(currentPosition.X - 1, currentPosition.Y);
            Point rt = new Point(currentPosition.X + 1, currentPosition.Y);

            if (positionChar == 'S')
            {
                if ("|F7".Contains(charAt(lines, up)) && !previousPosition.Equals(up)) return up;
                if ("-J7".Contains(charAt(lines, rt)) && !previousPosition.Equals(rt)) return rt;
                if ("|JL".Contains(charAt(lines, dn)) && !previousPosition.Equals(dn)) return dn;
                if ("-FL".Contains(charAt(lines, lt)) && !previousPosition.Equals(lt)) return lt;
            }
            else if (positionChar == '|')
            {
                if (previousPosition.Equals(up)) return dn; else return up;
            }
            else if (positionChar == '-')
            {
                if (previousPosition.Equals(lt)) return rt; else return lt;
            }
            else if (positionChar == 'F')
            {
                if (previousPosition.Equals(rt)) return dn; else return rt;
            }
            else if (positionChar == '7')
            {
                if (previousPosition.Equals(lt)) return dn; else return lt;
            }
            else if (positionChar == 'J')
            {
                if (previousPosition.Equals(up)) return lt; else return up;
            }
            else if (positionChar == 'L')
            {
                if (previousPosition.Equals(up)) return rt; else return up;
            }

            throw new Exception("Can't calculate next position with current position " + currentPosition + "(" + positionChar + "), previous " + previousPosition);
        }

        private char charAt(string[] lines, Point check)
        {
            if (check.X < 0 || check.Y < 0 || check.X >= lines[0].Length || check.Y >= lines.Length) return '.';

            return lines[check.Y][check.X];
        }

        private Point findStartingPoint(string[] lines)
        {
            for (int i=0; i<lines.Length; i++)
            {
                int pos = lines[i].IndexOf('S');
                if (pos >= 0) return new Point(pos, i);
            }
            throw new Exception("No starting point found");
        }

    }
}
