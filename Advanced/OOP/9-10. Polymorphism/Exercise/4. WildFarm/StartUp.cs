using E4WildFarm.Core;
using E4WildFarm.Core.Contracts;
using System;

namespace E4WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            IEngine engine = new Engine();

            engine.Run();




        }
    }
}
