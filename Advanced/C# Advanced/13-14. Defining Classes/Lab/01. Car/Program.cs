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

            Console.WriteLine($"{car.Make} - {car.Model} - {car.Year}");



        }
    }
}
