

using E7MilitaryElite.IO.Contracts;
using System;

namespace E7MilitaryElite.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
