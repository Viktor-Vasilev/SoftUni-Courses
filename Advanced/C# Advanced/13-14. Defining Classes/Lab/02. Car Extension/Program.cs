using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "Opel";
            car.Year = 2003;
            car.Model = "Corsa";

            car.FuelConsumption = 12;
            car.FuelQuantity = 200;

            car.Drive(20);
            car.Drive(10);

            Console.WriteLine(car.WhoAmI());


        }
    }
}
