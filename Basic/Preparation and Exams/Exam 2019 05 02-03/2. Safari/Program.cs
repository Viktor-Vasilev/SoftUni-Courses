using System;

namespace Izpit_20190502_2._Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double litersFuelNeeded = double.Parse(Console.ReadLine());
            string DayOfWeek = Console.ReadLine();

            double priceFor1LiterFuel = 2.10;
            double priceGuide = 100;

            double totalFuel = litersFuelNeeded * priceFor1LiterFuel;
            double totalCosts = 0.00;

            if (DayOfWeek == "Saturday")
            {
                totalCosts = (totalFuel + priceGuide) * 0.90;
            }
            else if (DayOfWeek == "Sunday")
            {
                totalCosts = (totalFuel + priceGuide) * 0.80;
            }
            if (budget > totalCosts)
            {
                Console.WriteLine($"Safari time! Money left: {budget - totalCosts:F2} lv. ");
            }
            else if (budget < totalCosts)
            {
                Console.WriteLine($"Not enough money! Money needed: {totalCosts - budget:F2} lv.");
            }



        }
    }
}
