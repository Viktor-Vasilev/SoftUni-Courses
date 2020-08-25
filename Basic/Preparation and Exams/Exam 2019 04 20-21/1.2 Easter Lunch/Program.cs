using System;

namespace Izpit_20190420_1._2_Easter_Lunch
{
    class Program
    {
        static void Main(string[] args)
        {
            int numKozunaci = int.Parse(Console.ReadLine());
            int numPacketsOfEggs = int.Parse(Console.ReadLine());
            int numKgKurabii = int.Parse(Console.ReadLine());

            double priceKozunak = 3.20;
            double pricePacketsOfEggs = 4.35;
            double priceKgKurabii = 5.40;
            double PriceColorForSingleEgg = 0.15;

            double priceColoringEggs = numPacketsOfEggs * 12 * 0.15;
            double total = ((numKozunaci * priceKozunak) + (numKgKurabii * priceKgKurabii) + (numPacketsOfEggs * pricePacketsOfEggs) + priceColoringEggs);
            Console.WriteLine($"{total:F2}");  

        }
    }
}
