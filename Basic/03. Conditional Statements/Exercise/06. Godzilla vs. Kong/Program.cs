using System;

namespace _06._Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double PriceClothingFor1Statist = double.Parse(Console.ReadLine());
            double decor = budget * 0.10;
            double sumClothing = statists * PriceClothingFor1Statist;
            if (statists > 150)
            {
                sumClothing = sumClothing * 0.90;
            }
            double pricefilm = decor + sumClothing;
            if (pricefilm <= budget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - pricefilm:F2} leva left.");
            }
            else if (pricefilm > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {pricefilm - budget:F2} leva more.");

            }
        }
    }
}
