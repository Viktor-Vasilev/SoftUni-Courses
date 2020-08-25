using System;

namespace _10._Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string grade = Console.ReadLine();

            int nights = days - 1;
            double price = 0;

            if (room == "room for one person")
            {
                price = 18.00;
            }
            else if (room == "apartment")
            {
                if (days < 10)
                {
                    price = 25 * 0.70;
                }
                else if (days >= 10 && days <= 15)
                {
                    price = 25 * 0.65;
                }
                else if (days > 15)
                {
                    price = 25 * 0.50;
                }
            }
            else if (room == "president apartment")
            {
                if (days < 10)
                {
                    price = 35 * 0.90;
                }
                else if (days >= 10 && days <= 15)
                {
                    price = 35 * 0.85;
                }
                else if (days > 15)
                {
                    price = 35 * 0.80;
                }
            }

            double total = nights * price;

            if (grade == "positive")
            {
                total = total + (total * 0.25);
                Console.WriteLine($"{total:F2}");
            }
            else if (grade == "negative")
            {
                total = (total - (total * 0.10));
                Console.WriteLine($"{total:F2}");
            }
        }
    }
}
