using System;

namespace _04._New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfFLower = Console.ReadLine();
            int numOfFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double price = 0;


            if (typeOfFLower == "Roses" && numOfFlowers > 80)
            {
                price = 5.00 * 0.90;
            }
            else if (typeOfFLower == "Roses" && numOfFlowers <= 80)
            {
                price = 5.00;
            }
            else if (typeOfFLower == "Dahlias" && numOfFlowers > 90)
            {
                price = 3.80 * 0.85;
            }
            else if (typeOfFLower == "Dahlias" && numOfFlowers <= 90)
            {
                price = 3.80;
            }
            else if (typeOfFLower == "Tulips" && numOfFlowers > 80)
            {
                price = 2.80 * 0.85;
            }
            else if (typeOfFLower == "Tulips" && numOfFlowers <= 80)
            {
                price = 2.80;
            }
            else if (typeOfFLower == "Narcissus" && numOfFlowers >= 120)
            {
                price = 3.00;
            }
            else if (typeOfFLower == "Narcissus" && numOfFlowers < 120)
            {
                price = 3.00 * 1.15;
            }
            else if (typeOfFLower == "Gladiolus" && numOfFlowers >= 80)
            {
                price = 2.50;
            }
            else if (typeOfFLower == "Gladiolus" && numOfFlowers < 80)
            {
                price = 2.50 * 1.20;
            }

            double total = numOfFlowers * price;

            if (budget >= total)
            {
                Console.WriteLine($"Hey, you have a great garden with {numOfFlowers} {typeOfFLower} and {budget - total:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {total - budget:F2} leva more.");
            }
        }
    }
}
