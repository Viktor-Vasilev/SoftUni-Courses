using E7MilitaryElite.Core;
using E7MilitaryElite.Core.Contracts;
using E7MilitaryElite.IO;
using E7MilitaryElite.IO.Contracts;
using System;

namespace E7MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);

            engine.Run();


        }
    }
}
