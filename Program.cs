using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReadInput().Solve());
        }

        private static List<int> ReadInput()
        {
            List<int> lines = new List<int>();

            foreach(string line in File.ReadAllLines("Input.txt"))
                lines.Add(Int32.Parse(line));

            return lines;
        }

        private static int Solve(this List<int> input)
        {
            HashSet<int> visitedComplements = new HashSet<int>();

            foreach(int candidate in input)
            {
                visitedComplements.Add(candidate);

                int candidateComplement = 2020 - candidate;

                if (visitedComplements.Contains(candidateComplement))
                    return candidate * candidateComplement;
            }

            return 0;
        }
    }
}
