using System.Collections.Generic;

namespace AdventOfCode.Core
{
    internal interface InputReader
    {
        List<string> Read(string fileName);
    }
}