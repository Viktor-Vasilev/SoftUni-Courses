using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            Engine engine = new Engine(89, 1700);
            Tire[] tires = new Tire[]
            {
            new Tire(2017, 1200),
            new Tire(2018, 1200),
            };

            Car opel = new Car("Opel", "Corsa", 2003, 40, 6.5, engine, tires);

            Console.WriteLine($"{opel.Make} - {opel.Model} - {opel.Year} - {opel.FuelQuantity} - {opel.FuelConsumption}");



        }
    }
}
