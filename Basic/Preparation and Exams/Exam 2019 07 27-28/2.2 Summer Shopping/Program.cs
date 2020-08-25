using System;

namespace Izpit_20190727_2._2_Summer_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            double priceHavliq = double.Parse(Console.ReadLine());
            double otstypkaPercent = double.Parse(Console.ReadLine());

            double priceChadyr = priceHavliq * 2 / 3;
            double priceJapanki = priceChadyr * 0.75;
            double priceChanta = (priceHavliq + priceJapanki) / 3;
            double totalcosts = priceJapanki + priceHavliq + priceChanta + priceChadyr;
            double otstypkaLeva = (totalcosts * otstypkaPercent) / 100;
            double total = totalcosts - otstypkaLeva;
            
            if (budget >= total)
            {
                Console.WriteLine($"Annie's sum is {total:F2} lv. She has {budget - total:F2} lv. left.");
            }
            else
            {
                Console.WriteLine($"Annie's sum is {total:F2} lv. She needs {total - budget:F2} lv. more.");
            }



        }
    }
}
