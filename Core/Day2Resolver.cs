using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Core
{
    internal sealed class Day2Resolver
    {
        private readonly InputReader _inputReader;
        public Day2Resolver(InputReader inputReader)
        {
            _inputReader = inputReader ?? throw new System.ArgumentNullException(nameof(inputReader));
        }

        private class Password 
        {
            public int FirstRequirement {get; set;}
            public int SecondRequirement {get; set;}
            public char RequiredLetter {get; set;}
            public string Value {get; set;}
        }

        public int SolveFirstPart()
        {
            int validPasswords = 0;

            foreach(Password password in GetPasswords())
            {
                int requiredLetterCount = password.Value.Count( x => x == password.RequiredLetter );

                if (requiredLetterCount >= password.FirstRequirement && requiredLetterCount <= password.SecondRequirement)
                    validPasswords++;
            }

            return validPasswords;
        }

        public int SolveSecondPart()
        {
            int validPasswords = 0;

            foreach(Password password in GetPasswords())
            {
                password.FirstRequirement--;
                password.SecondRequirement--;

                if (password.FirstRequirement < 0 || password.FirstRequirement >= password.Value.Length ||
                    password.SecondRequirement < 0 || password.SecondRequirement >= password.Value.Length)
                    continue;

                bool firstRequired = password.Value.ElementAt(password.FirstRequirement) == password.RequiredLetter;
                bool secondRequired = password.Value.ElementAt(password.SecondRequirement) == password.RequiredLetter;

                if (firstRequired ^ secondRequired)
                    validPasswords++;
            }

            return validPasswords;
        }

        private List<Password> GetPasswords()
        {
            List<Password> passwords = new List<Password>();

            _inputReader.Read("Inputs/InputDay2.txt").ForEach(inputLine => {
                passwords.Add(new Password {
                    FirstRequirement = Int32.Parse(inputLine.Substring(0, inputLine.IndexOf('-'))),
                    SecondRequirement = Int32.Parse(inputLine.Substring(inputLine.IndexOf('-') + 1, inputLine.IndexOf(' ') - inputLine.IndexOf('-') - 1)),
                    RequiredLetter = char.Parse(inputLine.Substring(inputLine.IndexOf(' ') + 1, inputLine.IndexOf(':') - inputLine.IndexOf(' ') - 1)),
                    Value = inputLine.Substring(inputLine.IndexOf(':') + 2)
                });
            });

            return passwords;
        }
    }
}