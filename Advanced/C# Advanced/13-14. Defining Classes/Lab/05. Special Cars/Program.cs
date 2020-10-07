using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "No more tires")
                {
                    break;
                }

                string[] tiresData = command.Split();

                List<Tire> tiresList = new List<Tire>();

                for (int i = 0; i < tiresData.Length; i += 2)
                {
                    int year = int.Parse(tiresData[i]);
                    double pressure = double.Parse(tiresData[i + 1]);

                    Tire tire = new Tire(year, pressure);

                    tiresList.Add(tire);
                }

                tires.Add(tiresList.ToArray());
            }

            List<Engine> engines = new List<Engine>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Engines done")
                {
                    break;
                }

                string[] enginesData = command.Split();

                int horsePower = int.Parse(enginesData[0]);
                double cubicCapacity = double.Parse(enginesData[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);

                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Show special")
                {
                    break;
                }

                string[] carData = command.Split();

                string make = carData[0];
                string model = carData[1];
                int year = int.Parse(carData[2]);
                double fuelQuantity = double.Parse(carData[3]);
                double fuelConsumption = double.Parse(carData[4]);
                int engineIndex = int.Parse(carData[5]);
                int tiresIndex = int.Parse(carData[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);

                cars.Add(car);
            }

            var specialCars = cars
                .Where(x => x.Year >= 2017)
                .Where(x => x.Engine.HorsePower > 330) 
                .Where(x => x.Tires.Sum(y => y.Pressure) > 9)
                .Where(x => x.Tires.Sum(y => y.Pressure) < 10)
                .ToList();

            //resultCars.ForEach(x => x.Drive(20));

            foreach (Car car in specialCars)
            {
                car.Drive(20);
                Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\n" +
                    $"Year: {car.Year}\nHorsePowers: {car.Engine.HorsePower}\n" +
                    $"FuelQuantity: {car.FuelQuantity:f1}");
            }


        }
    }
}
