using System;

namespace _06._Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "";
            string typeOfStay = "";
            double total = 0;

            if (budget <= 100)
            {
                if (season == "summer")
                {
                    destination = "Bulgaria";
                    typeOfStay = "Camp";
                    total = budget * 0.30;
                }
                else if (season == "winter")
                {
                    destination = "Bulgaria";
                    typeOfStay = "Hotel";
                    total = budget * 0.70;
                }
            }
            else if (budget <= 1000)
            {
                if (season == "summer")
                {
                    destination = "Balkans";
                    typeOfStay = "Camp";
                    total = budget * 0.40;
                }
                else if (season == "winter")
                {
                    destination = "Balkans";
                    typeOfStay = "Hotel";
                    total = budget * 0.80;
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                typeOfStay = "Hotel";
                total = budget * 0.90;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{typeOfStay} - {total:F2}");
        }
    }
}
