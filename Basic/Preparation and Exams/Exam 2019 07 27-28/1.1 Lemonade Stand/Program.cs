using System;

namespace Izpit_20190727_1._1_Lemonade_Stand
{
    class Program
    {
        static void Main(string[] args)
        {
            double kgLemons = double.Parse(Console.ReadLine());
            double kgSugar = double.Parse(Console.ReadLine());
            double litersWater = double.Parse(Console.ReadLine());
            double priceFor1Cup = 1.20;

            double lemonjuice = kgLemons * 0.980 * 1000;
            // Console.WriteLine(lemonjuice);
            double sugar = kgSugar * 0.3;

            double lemonadeTotalInMl = (lemonjuice + (litersWater * 1000) + sugar);
            // Console.WriteLine(lemonadeTotalInMl );

            double numCups = Math.Floor(lemonadeTotalInMl / 150);
            double totalMoney = numCups * priceFor1Cup;

            Console.WriteLine($"All cups sold: {numCups}");
            Console.WriteLine($"Money earned: {totalMoney:F2}");


        }
    }
}
