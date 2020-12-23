using System;
using System.Collections.Generic;

namespace AdventOfCode.Core
{
    internal sealed class Day1Resolver
    {
        private readonly InputReader _inputReader;
        public Day1Resolver(InputReader inputReader)
        {
            _inputReader = inputReader ?? throw new System.ArgumentNullException(nameof(inputReader));
        }

        public int SolveFirstPart()
        {
            List<int> reports = _inputReader.Read("Inputs/InputDay1.txt").ConvertAll( i => Int32.Parse(i) );

            HashSet<int> visitedComplements = new HashSet<int>();

            foreach(int candidate in reports)
            {
                visitedComplements.Add(candidate);

                int candidateComplement = 2020 - candidate;

                if (visitedComplements.Contains(candidateComplement))
                    return candidate * candidateComplement;
            }

            return 0;
        }

        public int SolveSecondPart()
        {
            List<int> reports = _inputReader.Read("Inputs/InputDay1.txt").ConvertAll( i => Int32.Parse(i) );

            foreach(int firstCandidate in reports)
            {
                HashSet<int> visitedComplements = new HashSet<int>();

                foreach(int secondCandidate in reports)
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