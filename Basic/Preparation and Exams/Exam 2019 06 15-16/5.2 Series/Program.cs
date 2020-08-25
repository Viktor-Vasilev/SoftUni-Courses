using System;

namespace Izpit_20190615_5._2_Series
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numSerials = int.Parse(Console.ReadLine());

            double totalCosts = 0;

            for (int i = 1; i <= numSerials; i++)
            {
                string nameSerial = Console.ReadLine();
                double priceSerial = double.Parse(Console.ReadLine());

                if (nameSerial == "Thrones")
                {
                    totalCosts += priceSerial * 0.50;
                }
                else if (nameSerial == "Lucifer")
                {
                    totalCosts += priceSerial * 0.60;
                }
                else if (nameSerial == "Protector")
                {
                    totalCosts += priceSerial * 0.70;
                }
                else if (nameSerial == "TotalDrama")
                {
                    totalCosts += priceSerial * 0.80;
                }
                else if (nameSerial == "Area")
                {
                    totalCosts += priceSerial * 0.90;
                }
                else
                {
                    totalCosts += priceSerial;
                }
            }

            double diff = Math.Abs(budget - totalCosts);

            if (budget >= totalCosts)
            {
                Console.WriteLine($"You bought all the series and left with {diff:F2} lv.");
            }
            else
            {
                Console.WriteLine($"You need {diff:F2} lv. more to buy the series!");
            }

        }
    }
}
