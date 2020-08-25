using System;

namespace Izpit_20190420_1._1_Easter_Bakery
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceFlour = double.Parse(Console.ReadLine());
            double kgFlour = double.Parse(Console.ReadLine());
            double kgSugar = double.Parse(Console.ReadLine());
            int boxesOfEggs = int.Parse(Console.ReadLine());
            int packetsOfYeast = int.Parse(Console.ReadLine());

            double priceSugar = priceFlour * 0.75;
            double priceboxesOfEggs = priceFlour * 1.10;
            double pricepacketOfYeast = priceSugar * 0.20;

            double total = ((priceFlour * kgFlour) + (priceSugar * kgSugar) + (priceboxesOfEggs * boxesOfEggs) + (pricepacketOfYeast * packetsOfYeast));

            Console.WriteLine($"{total:F2}");
        }
    }
}
