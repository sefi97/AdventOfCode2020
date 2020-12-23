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

            Console.WriteLine(day1Resolver.SolveFirstPart());
            Console.WriteLine(day1Resolver.SolveSecondPart());
            Console.WriteLine(inputReader.Read("Inputs/InputDay2.txt").SolveDay2FirstPart());
            Console.WriteLine(inputReader.Read("Inputs/InputDay2.txt").SolveDay2SecondPart());
        }

        private class Password {
            public int RequiredMin {get; set;}
            public int RequiredMax {get; set;}
            public char RequiredLetter {get; set;}
            public string Value {get; set;}
        }

        private static int SolveDay2FirstPart(this List<string> input)
        {
            List<Password> passwords = new List<Password>();

            input.ForEach(inputLine => {
                passwords.Add(new Password {
                    RequiredMin = Int32.Parse(inputLine.Substring(0, inputLine.IndexOf('-'))),
                    RequiredMax = Int32.Parse(inputLine.Substring(inputLine.IndexOf('-') + 1, inputLine.IndexOf(' ') - inputLine.IndexOf('-') - 1)),
                    RequiredLetter = char.Parse(inputLine.Substring(inputLine.IndexOf(' ') + 1, inputLine.IndexOf(':') - inputLine.IndexOf(' ') - 1)),
                    Value = inputLine.Substring(inputLine.IndexOf(':') + 2)
                });
            });

            int validPasswords = 0;

            foreach(Password password in passwords)
            {
                int requiredLetterCount = password.Value.Count( x => x == password.RequiredLetter );

                if (requiredLetterCount >= password.RequiredMin && requiredLetterCount <= password.RequiredMax)
                    validPasswords++;
            }

            return validPasswords;
        }

        private class NewPassword {
            public int FirstPosition {get; set;}
            public int SecondPosition {get; set;}
            public char RequiredLetter {get; set;}
            public string Value {get; set;}
        }

        private static int SolveDay2SecondPart(this List<string> input)
        {
            List<NewPassword> passwords = new List<NewPassword>();

            input.ForEach(inputLine => {
                passwords.Add(new NewPassword {
                    FirstPosition = Int32.Parse(inputLine.Substring(0, inputLine.IndexOf('-'))) - 1,
                    SecondPosition = Int32.Parse(inputLine.Substring(inputLine.IndexOf('-') + 1, inputLine.IndexOf(' ') - inputLine.IndexOf('-') - 1)) - 1,
                    RequiredLetter = char.Parse(inputLine.Substring(inputLine.IndexOf(' ') + 1, inputLine.IndexOf(':') - inputLine.IndexOf(' ') - 1)),
                    Value = inputLine.Substring(inputLine.IndexOf(':') + 2)
                });
            });

            int validPasswords = 0;

            foreach(NewPassword password in passwords)
            {
                if (password.FirstPosition < 0 || password.FirstPosition >= password.Value.Length ||
                    password.SecondPosition < 0 || password.SecondPosition >= password.Value.Length)
                    continue;

                bool firstRequired = password.Value.ElementAt(password.FirstPosition) == password.RequiredLetter;
                bool secondRequired = password.Value.ElementAt(password.SecondPosition) == password.RequiredLetter;

                if (firstRequired ^ secondRequired)
                    validPasswords++;
            }

            return validPasswords;
        }
    }
}
