using System;

namespace _06._Truck_Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kmForMonth = double.Parse(Console.ReadLine());

            double priceForKm = 0;

            if (season == "Spring" || season == "Autumn")
            {
                if (kmForMonth <= 5000)
                {
                    priceForKm = 0.75;
                }
                else if (kmForMonth > 5000 && kmForMonth <= 10000)
                {
                    priceForKm = 0.95;
                }
                else
                {
                    priceForKm = 1.45;
                }
            }
            else if (season == "Summer")
            {
                if (kmForMonth <= 5000)
                {
                    priceForKm = 0.90;
                }
                else if (kmForMonth > 5000 && kmForMonth <= 10000)
                {
                    priceForKm = 1.10;
                }
                else
                {
                    priceForKm = 1.45;
                }
            }
            else
            {
                if (kmForMonth <= 5000)
                {
                    priceForKm = 1.05;
                }
                else if (kmForMonth > 5000 && kmForMonth <= 10000)
                {
                    priceForKm = 1.25;
                }
                else
                {
                    priceForKm = 1.45;
                }
            }

            double totalLeva = kmForMonth * priceForKm * 4 * 0.90; //един сезон е 4 месеца, и се вади данъка


            Console.WriteLine($"{totalLeva:F2}");
        }
    }
}
