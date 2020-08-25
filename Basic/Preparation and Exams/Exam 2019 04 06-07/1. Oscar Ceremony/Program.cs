using System;

namespace Izpit_20190406_1._Oscar_Ceremony
{
    class Program
    {
        static void Main(string[] args)
        {
            int rentHall = int.Parse(Console.ReadLine());
            double priceStatues = rentHall * 0.70;
            double priceCatering = priceStatues * 0.85;
            double priceSounding = priceCatering * 0.50;
            double total = rentHall + priceStatues + priceCatering + priceSounding;
            Console.WriteLine($"{total:F2}");


        }
    }
}
