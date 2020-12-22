using System.Collections.Generic;
using System.IO;


namespace AdventOfCode.Helpers
{
    public class InputReader
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