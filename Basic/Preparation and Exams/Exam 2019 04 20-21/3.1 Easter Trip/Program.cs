using System;

namespace Izpit_20190420_3._1_Easter_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int numberOfNights = int.Parse(Console.ReadLine());

            double priceFor1Night = 0;

            if (destination == "France")
            {
                if (dates == "21-23")
                {
                    priceFor1Night = 30;
                }
                else if (dates == "24-27")
                {
                    priceFor1Night = 35;
                }
                else
                {
                    priceFor1Night = 40;
                }
            }
            else if (destination == "Italy")
            {
                if (dates == "21-23")
                {
                    priceFor1Night = 28;
                }
                else if (dates == "24-27")
                {
                    priceFor1Night = 32;
                }
                else
                {
                    priceFor1Night = 39;
                }
            }
            else
            {
                if (dates == "21-23")
                {
                    priceFor1Night = 32;
                }
                else if (dates == "24-27")
                {
                    priceFor1Night = 37;
                }
                else
                {
                    priceFor1Night = 43;
                }
            }

            double total = priceFor1Night * numberOfNights;

            Console.WriteLine($"Easter trip to {destination} : {total:F2} leva.");


        }
    }
}
