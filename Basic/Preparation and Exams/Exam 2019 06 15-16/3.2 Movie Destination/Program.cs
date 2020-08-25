using System;

namespace Izpit_20190615_3._2_Movie_Destination
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int numberOfDays = int.Parse(Console.ReadLine());

            double priceFor1Day = 0;

            if (destination == "Dubai")
            {
                if (season == "Winter")
                {
                    priceFor1Day = 45000;
                }
                else
                {
                    priceFor1Day = 40000;
                }
            }
            else if (destination == "Sofia")
            {
                if (season == "Winter")
                {
                    priceFor1Day = 17000;
                }
                else
                {
                    priceFor1Day = 12500;
                }
            }
            else
            {
                if (season == "Winter")
                {
                    priceFor1Day = 24000;
                }
                else
                {
                    priceFor1Day = 20250;
                }
            }     

            if (destination == "Dubai")
            {
                priceFor1Day = priceFor1Day * 0.70;
            }

            if (destination == "Sofia")
            {
                priceFor1Day = priceFor1Day * 1.25;
            }

            double total = priceFor1Day * numberOfDays;

            if (budget >= total)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {budget - total:F2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {total - budget:F2} leva more!");
            }

        }
    }
}
