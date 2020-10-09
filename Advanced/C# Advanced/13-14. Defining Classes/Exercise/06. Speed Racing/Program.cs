﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            
            for (int i = 0; i < n; i++)
            {
                string[] inputInfo = Console.ReadLine().Split(' ');

                string model = inputInfo[0];
                double fuelAmount = double.Parse(inputInfo[1]);
                double fuelConsumption = double.Parse(inputInfo[2]);
                
                
                Car car = new Car(model, fuelAmount, fuelConsumption);

                cars.Add(car);

            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] data = input.Split(' ');

                string model = data[1];
                int amountOfKm = int.Parse(data[2]);

               // Car car = GetCar(cars, model); -- с метода отдолу

                Car car = cars.FirstOrDefault(x => x.Model == model);

                car.Drive(amountOfKm);

                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }

        }

        private static Car GetCar(List<Car>cars, string model)
        {
            foreach (var car in cars)
            {
                if (car.Model == model)
                {
                    return car;
                }             
            }

            return null;
        }
    }
}
