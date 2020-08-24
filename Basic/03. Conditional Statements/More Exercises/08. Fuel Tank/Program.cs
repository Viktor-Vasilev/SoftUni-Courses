using System;

namespace _08._Fuel_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            string TypeOfFuel = Console.ReadLine().ToLower();
            int tankLevel = int.Parse(Console.ReadLine());

            if (TypeOfFuel == "diesel" || TypeOfFuel == "gas" || TypeOfFuel == "gasoline")
            {
                if (tankLevel >= 25)
                {
                    Console.WriteLine($"You have enough {TypeOfFuel}.");
                }
                else
                {
                    Console.WriteLine($"Fill your tank with {TypeOfFuel}!");
                }
            }
            else
            {
                Console.WriteLine("Invalid fuel!");

            }
        }
    }
}
