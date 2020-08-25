using System;

namespace Izpit_20190727_6._2_Trip_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());

            double moneyLeft = 0.0;

            for (int i = 0; i < days; i++)
            {
                double dayLimit = 60 + moneyLeft;
                moneyLeft = 0;
                string command = Console.ReadLine();
                int products = 0;
                while (command != "Day over")
                {
                    double price = double.Parse(command);
                    if (dayLimit - price >= 0)
                    {
                        dayLimit -= price;
                        products++;
                    }
                    else
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    if (dayLimit == 0)
                    {
                        break;
                    }
                    command = Console.ReadLine();
                }
                if (command == "Day over")
                {
                    moneyLeft = Math.Abs(moneyLeft - dayLimit);
                    Console.WriteLine($"Money left from today: {moneyLeft:F2}. You've bought {products} products.");
                }
                else
                {
                    Console.WriteLine($"Daily limit exceeded! You've bought {products} products.");
                }

            }
        }
    }
}
