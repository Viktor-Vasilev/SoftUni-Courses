using System;

namespace _05._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string location = "";
            string place = "";

            if (budget <= 1000)
            {
                place = "Camp";
                if (season == "Summer")
                {
                    location = "Alaska";
                    budget = budget * 0.65;
                }
                else
                {
                    location = "Morocco";
                    budget = budget * 0.45;
                }
            }
            if (budget > 1000 && budget <= 3000)
            {
                place = "Hut";
                if (season == "Summer")
                {
                    location = "Alaska";
                    budget = budget * 0.80;
                }
                else
                {
                    location = "Morocco";
                    budget = budget * 0.60;
                }
            }
            if (budget > 3000)
            {
                place = "Hotel";
                budget = budget * 0.90;
                if (season == "Summer")
                {
                    location = "Alaska";
                }
                else
                {
                    location = "Morocco";
                }

            }

            Console.WriteLine($"{location} - {place} - {budget:F2}");
        }
    }
}
