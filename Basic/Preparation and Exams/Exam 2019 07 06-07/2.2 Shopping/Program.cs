using System;

namespace Izpit_20190706_2._2_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numVideoCards = int.Parse(Console.ReadLine());
            int numProcessors = int.Parse(Console.ReadLine());
            int numRam = int.Parse(Console.ReadLine());

            double priceVideoCard = 250.00;
            double priceProcessor = (numVideoCards * 1.0 * priceVideoCard) * 35 / 100;
            double priceRam = (numVideoCards * 1.0 * priceVideoCard) * 10 / 100;

            double total = 0;

            if (numVideoCards > numProcessors)
            {
                total = (numVideoCards * priceVideoCard + numProcessors * priceProcessor + numRam * priceRam) * 0.85;    
            }
            else
            {
                total = (numVideoCards * priceVideoCard + numProcessors * priceProcessor + numRam * priceRam);
            }
            if (total <= budget)
            {
                Console.WriteLine($"You have {budget - total:F2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {total - budget:F2} leva more!");
            }


        }
    }
}
