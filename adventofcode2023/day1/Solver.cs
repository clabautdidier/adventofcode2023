using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2023.day1
{
    public class Solver
    {
        public int Part1(String[] Lines)  
        {
            return Lines.ToList().ConvertAll(line => this.ToNumber(line)).Sum();
        }
        
        public int Part2(String[] Lines)  
        {
            return Lines.ToList().ConvertAll(line => this.ToNumber2(line)).Sum();
        }

        private int ToNumber2(string line)
        {
            String l = line
                .Replace("zero", "zero0zero")
                .Replace("one", "one1one")
                .Replace("two", "two2two")
                .Replace("three", "three3three")
                .Replace("four", "four4four")
                .Replace("five", "five5five")
                .Replace("six", "six6six")
                .Replace("seven", "seven7seven")
                .Replace("eight", "eight8eight")
                .Replace("nine", "nine9nine");

            //System.Console.WriteLine(line + " ==> " + l);
            return ToNumber(l);
        }

        private int ToNumber(string line)
        {
            char n1 = line.ElementAt(line.IndexOfAny(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }));
            char n2 = line.ElementAt(line.LastIndexOfAny(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }));

            return int.Parse(""+n1+n2);
        }
    }
}
