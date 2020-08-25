using System;

namespace Izpit_20190502_1._Food_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int numChickenMenu = int.Parse(Console.ReadLine());
            int numFishMenu = int.Parse(Console.ReadLine());
            int numVegetarianMenu = int.Parse(Console.ReadLine());

            double priceChickenMenu = 10.35;
            double priceFishMenu = 12.40;
            double priceVegetarianMenu = 8.15;

            double total = ((numChickenMenu * priceChickenMenu) + (numFishMenu * priceFishMenu) + (numVegetarianMenu * priceVegetarianMenu));
            double desert = total * 0.20;
            double supply = 2.50;
            double grandTotal = total + desert + supply;
            Console.WriteLine($"Total: {grandTotal:F2}");

        }
    }
}
