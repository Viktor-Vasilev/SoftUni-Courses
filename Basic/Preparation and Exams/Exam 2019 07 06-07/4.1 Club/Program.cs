using System;

namespace Izpit_20190706_4._1_Club
{
    class Program
    {
        static void Main(string[] args)
        {
            double aimProfit = double.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            double moneySoFar = 0;

            double priceCurrentOrder = 0;

            double priceDrink = 0;

            while (command != "Party!")
            {
                
                int numDrinks = int.Parse(Console.ReadLine());

                priceDrink = command.Length;

                priceCurrentOrder = priceDrink * numDrinks;

                if (priceCurrentOrder % 2 != 0)
                {
                    moneySoFar += priceCurrentOrder * 0.75;
                }

                if (priceCurrentOrder % 2 == 0)
                {
                    moneySoFar += priceCurrentOrder;
                }

                if (moneySoFar >= aimProfit)
                {
                    Console.WriteLine("Target acquired.");
                    Console.WriteLine($"Club income - {moneySoFar:F2} leva.");
                    break;
                }

                command = Console.ReadLine();
            }

            if (command == "Party!")
            {
                Console.WriteLine($"We need {aimProfit - moneySoFar:F2} leva more.");
                Console.WriteLine($"Club income - {moneySoFar:F2} leva.");
            }

        }
    }
}
