using System;

namespace _03._Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            int hrizantemi = int.Parse(Console.ReadLine());
            int rozi = int.Parse(Console.ReadLine());
            int laleta = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string day = Console.ReadLine();

            double priceHrizantemi = 0;
            double priceRozi = 0;
            double priceLaleta = 0;

            if (season == "Spring" || season == "Summer")
            {
                priceHrizantemi = 2.00;
                priceRozi = 4.10;
                priceLaleta = 2.50;
                if (day == "Y")
                {
                    priceHrizantemi = 2.00 * 1.15;
                    priceRozi = 4.10 * 1.15;
                    priceLaleta = 2.50 * 1.15;
                }
            }
            else
            {
                priceHrizantemi = 3.75;
                priceRozi = 4.50;
                priceLaleta = 4.15;
                if (day == "Y")
                {
                    priceHrizantemi = 3.75 * 1.15;
                    priceRozi = 4.50 * 1.15;
                    priceLaleta = 4.15 * 1.15;
                }
            }

            double priceBuket = (hrizantemi * priceHrizantemi) + (rozi * priceRozi) + (laleta * priceLaleta);

            if (season == "Spring" && laleta > 7)
            {
                priceBuket = priceBuket * 0.95;
            }

            if (season == "Winter" && rozi >= 10)
            {
                priceBuket = priceBuket * 0.90;
            }

            if ((hrizantemi + rozi + laleta) > 20)
            {
                priceBuket = priceBuket * 0.80;
            }

            double aranjirane = 2.00;

            Console.WriteLine($"{priceBuket + aranjirane:F2}");
        }
    }
}
