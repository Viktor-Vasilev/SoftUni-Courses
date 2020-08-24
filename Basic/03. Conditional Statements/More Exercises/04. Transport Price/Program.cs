using System;

namespace _04._Transport_Price
{
    class Program
    {
        static void Main(string[] args)
        {
            int km = int.Parse(Console.ReadLine());
            string TimeOfDay = Console.ReadLine();
            double nachalnaTaksaTaksi = 0.70;
            double priceTaxiDay = 0.79;
            double priceTaxiNight = 0.90;
            double priceAvtobus = 0.09;
            double priceVlak = 0.06;

            if (km >= 20 && km < 100)
            {
                double priceTrip = priceAvtobus * km;
                Console.WriteLine($"{priceTrip:F2}");
            }
            else if (km >= 100)
            {
                double priceTrip = priceVlak * km;
                Console.WriteLine($"{priceTrip:F2}");
            }
            else if (km < 20)
                if (TimeOfDay == "day")
                {
                    double priceTrip = (nachalnaTaksaTaksi + (priceTaxiDay * km));
                    Console.WriteLine($"{priceTrip:F2}");
                }
                else if (TimeOfDay == "night")
                {
                    double priceTrip = (nachalnaTaksaTaksi + (priceTaxiNight * km));
                    Console.WriteLine($"{priceTrip:F2}");
                }
        }
    }
}
