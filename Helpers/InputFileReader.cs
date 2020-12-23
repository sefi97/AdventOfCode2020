using System.Collections.Generic;
using System.IO;
using AdventOfCode.Core;

namespace AdventOfCode.Helpers
{
    internal class InputFileReader : InputReader
    {
        public List<string> Read(string fileName)
        {
            List<string> lines = new List<string>();

            foreach (string line in File.ReadAllLines(fileName))
                lines.Add(line);

            return lines;
        }
    }
}