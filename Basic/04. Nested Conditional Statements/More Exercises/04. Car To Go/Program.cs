using System;

namespace _04._Car_To_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string typeOfCar = "";
            string typeOfClass = "";

            if (budget <= 100 && season == "Summer")
            {
                typeOfClass = "Economy class";
                typeOfCar = "Cabrio";
                budget = budget * 0.35;
            }
            if (budget <= 100 && season == "Winter")
            {
                typeOfClass = "Economy class";
                typeOfCar = "Jeep";
                budget = budget * 0.65;
            }
            if ((budget > 100 && budget <= 500) && season == "Summer")
            {
                typeOfClass = "Compact class";
                typeOfCar = "Cabrio";
                budget = budget * 0.45;
            }
            if ((budget > 100 && budget <= 500) && season == "Winter")
            {
                typeOfClass = "Compact class";
                typeOfCar = "Jeep";
                budget = budget * 0.80;
            }
            if (budget > 500)
            {
                typeOfClass = "Luxury class";
                typeOfCar = "Jeep";
                budget = budget * 0.90;
            }

            Console.WriteLine($"{typeOfClass}");
            Console.WriteLine($"{typeOfCar} - {budget:F2}");
        }
    }
}
