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
            Console.WriteLine(ReadInput("Inputs/InputDay1.txt").SolveDay1FirstPart());
            Console.WriteLine(ReadInput("Inputs/InputDay1.txt").SolveDay1SecondPart());
        }

        private static List<string> ReadInput(string fileName)
        {
            List<string> lines = new List<string>();

            foreach(string line in File.ReadAllLines(fileName))
                lines.Add(line);

            return lines;
        }

        private static int SolveDay1FirstPart(this List<string> input)
        {
            HashSet<int> visitedComplements = new HashSet<int>();

            foreach(int candidate in input.ConvertAll( i => Int32.Parse(i)))
            {
                visitedComplements.Add(candidate);

                int candidateComplement = 2020 - candidate;

                if (visitedComplements.Contains(candidateComplement))
                    return candidate * candidateComplement;
            }

            return 0;
        }

        
        private static int SolveDay1SecondPart(this List<string> input)
        {
            foreach(int firstCandidate in input.ConvertAll(i => Int32.Parse(i)))
            {
                HashSet<int> visitedComplements = new HashSet<int>();

                foreach(int secondCandidate in input.ConvertAll(i => Int32.Parse(i)))
                {
                    visitedComplements.Add(secondCandidate);

                    int candidatesComplement = 2020 - firstCandidate - secondCandidate;

                    if (visitedComplements.Contains(candidatesComplement))
                        return firstCandidate * secondCandidate * candidatesComplement;
                }
            }

            return 0;
        }
    }
}
