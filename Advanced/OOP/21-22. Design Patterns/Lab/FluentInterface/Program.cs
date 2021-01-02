using Builder;
using System;

namespace FluentInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            CarBuilder builder = new CarBuilder();

            builder.BuildEngine(car)
                 .BuildKutiq(car)
                 .BuildTyres(car)
                 .BuildKutiq(car)
                 .BuildTyres(car)
                 .BuildKutiq(car)
                 .BuildTyres(car);

            Console.WriteLine(car.Engine);
            Console.WriteLine(car.Kitiq);
            Console.WriteLine(car.Tyres);
        }
    }
}
