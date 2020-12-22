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
            Console.WriteLine(ReadInput().SolveFirstPart());
            Console.WriteLine(ReadInput().SolveSecondPart());
        }

        private static List<int> ReadInput()
        {
            List<int> lines = new List<int>();

            foreach(string line in File.ReadAllLines("Inputs/Input.txt"))
                lines.Add(Int32.Parse(line));

            return lines;
        }

        private static int SolveFirstPart(this List<int> input)
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

        
        private static int SolveSecondPart(this List<int> input)
        {
            foreach(int firstCandidate in input)
            {
                HashSet<int> visitedComplements = new HashSet<int>();

                foreach(int secondCandidate in input)
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
