using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
             .Info
               .WithType("Opel")
               .WithColor("Orange")
               .WithNumberOfDoors(5)
             .Built
               .InCity("Munich ")
               .AtAddress("GG 254")
             .Build();

            Console.WriteLine(car);




        }
    }
}
