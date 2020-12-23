using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using AdventOfCode.Helpers;

namespace AdventOfCode
{
    static class Program
    {
        static void Main(string[] args)
        {
            InputFileReader inputReader = new InputFileReader();
            Day1Resolver day1Resolver = new Day1Resolver(inputReader);
            Day2Resolver day2Resolver = new Day2Resolver(inputReader);

            Console.WriteLine(day1Resolver.SolveFirstPart());
            Console.WriteLine(day1Resolver.SolveSecondPart());
            Console.WriteLine(day2Resolver.SolveFirstPart());
            Console.WriteLine(day2Resolver.SolveSecondPart());
        }
    }
}
