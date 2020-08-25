using System;

namespace _05._Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermans = int.Parse(Console.ReadLine());

            double price = 0;

            switch (season)
            {
                case "Spring":
                    price = 3000;
                    break;
                case "Summer":
                    price = 4200;
                    break;
                case "Autumn":
                    price = 4200;
                    break;
                case "Winter":
                    price = 2600;
                    break;
            }

            if (fishermans <= 6)
            {
                price = price * 0.90;
            }
            else if (fishermans >= 7 && fishermans <= 11)
            {
                price = price * 0.85;
            }
            else if (fishermans >= 12)
            {
                price = price * 0.75;
            }

            if (season != "Autumn" && fishermans * 1.0 % 2 == 0)
            {
                price = price * 0.95;
            }



            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {budget - price:F2} leva left.");
            }
            else if (price > budget)
            {
                Console.WriteLine($"Not enough money! You need {price - budget:F2} leva.");
            }
        }
    }
}
