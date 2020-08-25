using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20200410_Retake_03_Need_For_Speed_III_With_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string,List<int>> cars = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

                var name = carInfo[0];
                var mileage = int.Parse(carInfo[1]);
                var fuel = int.Parse(carInfo[2]);

                cars.Add(name, new List<int>()
                {
                    mileage, fuel
                });
            }

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                var tokens = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                var carName = tokens[1];

                if (command.Contains("Drive"))
                {

                    var distance = int.Parse(tokens[2]);
                    var fuel = int.Parse(tokens[3]);

                    var carFuel = cars[carName][1];

                    if (fuel > carFuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[carName][0] += distance;
                        cars[carName][1] -= fuel;

                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                        if (cars[carName][0] >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {carName}!");
                            cars.Remove(carName);
                        }
                    }

                }
                else if (command.Contains("Refuel"))
                {

                    var fuelToAdd = int.Parse(tokens[2]);

                    var currentFuel = cars[carName][1];

                    if (fuelToAdd + currentFuel > 75)
                    {
                        fuelToAdd = 75 - currentFuel;
                    }

                    cars[carName][1] += fuelToAdd;

                    Console.WriteLine($"{carName} refueled with {fuelToAdd} liters");
                }

                else if (command.Contains("Revert"))
                {

                    var kilometers = int.Parse(tokens[2]);

                    cars[carName][0] -= kilometers;

                    if (cars[carName][0] < 10000)
                    {
                        cars[carName][0] = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
                    }

                }

                command = Console.ReadLine();
            }

            var ordered = cars.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key);

            foreach (var car in ordered)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
            }

        }
    }
}
