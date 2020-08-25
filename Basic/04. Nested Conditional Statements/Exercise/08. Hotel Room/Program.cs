using System;

namespace _08._Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double priceStudio = 0;
            double priceApartment = 0;

            if (nights >= 1 && nights <= 7 && (month == "May" || month == "October"))
            {
                priceStudio = 50.00;
                priceApartment = 65.00;
            }
            else if ((nights >= 1) && (nights <= 7) && (month == "June" || month == "September"))
            {
                priceStudio = 75.20;
                priceApartment = 68.70;
            }
            else if ((nights >= 1) && (nights <= 7) && (month == "July" || month == "August"))
            {
                priceStudio = 76.00;
                priceApartment = 77.00;
            }
            else if (nights > 7 && nights <= 14 && (month == "May" || month == "October"))
            {
                priceStudio = 50.00 * 0.95;
                priceApartment = 65.00;
            }
            else if ((nights > 7) && (nights <= 14) && (month == "June" || month == "September"))
            {
                priceStudio = 75.20;
                priceApartment = 68.70;
            }
            else if ((nights > 7) && (nights <= 14) && (month == "July" || month == "August"))
            {
                priceStudio = 76.00;
                priceApartment = 77.00;
            }
            else if ((nights > 14) && (month == "May" || month == "October"))
            {
                priceStudio = 50.00 * 0.70;
                priceApartment = 65.00 * 0.90;
            }
            else if ((nights > 14) && (month == "June" || month == "September"))
            {
                priceStudio = 75.20 * 0.80;
                priceApartment = 68.70 * 0.90;
            }
            else if ((nights > 14) && (month == "July" || month == "August"))
            {
                priceStudio = 76.00;
                priceApartment = 77.00 * 0.90;
            }

            double totalApartment = nights * priceApartment;
            double totalStudio = nights * priceStudio;


            Console.WriteLine($"Apartment: {totalApartment:F2} lv.");
            Console.WriteLine($"Studio: {totalStudio:F2} lv.");
        }
    }
}
