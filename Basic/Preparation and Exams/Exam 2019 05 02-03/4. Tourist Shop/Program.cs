using System;

namespace Izpit_20190502_4._Tourist_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            int productsBought = 0;
            double spentMoney = 0;

            while (command != "Stop")
            {
                double currentProductPrice = double.Parse(Console.ReadLine());

                productsBought++;

                if (productsBought % 3 == 0)
                {
                    currentProductPrice *= 0.5;
                }

                if (currentProductPrice > budget)
                {
                    Console.WriteLine($"You don't have enough money!");
                    Console.WriteLine($"You need {currentProductPrice - budget:f2} leva!");
                    break;
                }

                budget -= currentProductPrice;

                spentMoney += currentProductPrice;

                command = Console.ReadLine();

            }

            if (command == "Stop")
            {
                Console.WriteLine($"You bought {productsBought} products for {spentMoney:f2} leva.");
            }
        }
    }
}
