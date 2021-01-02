using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            CarBuilder builder = new CarBuilder();

            builder.BuildEngine(car);
            builder.BuildKutiq(car);
            builder.BuildTyres(car);

            Console.WriteLine(car.Engine);
            Console.WriteLine(car.Kitiq);
            Console.WriteLine(car.Tyres);
        }
    }
}
