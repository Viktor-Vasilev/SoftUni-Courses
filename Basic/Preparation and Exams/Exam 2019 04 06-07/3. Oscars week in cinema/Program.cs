using System;

namespace Izpit_20190406_3._Oscars_week_in_cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            string hall = Console.ReadLine();
            int numTickets = int.Parse(Console.ReadLine());

            double priceTicket = 0;

            if (movieName == "A Star Is Born")
            {
                if (hall == "normal")
                {
                    priceTicket = 7.50;
                }
                else if (hall == "luxury")
                {
                    priceTicket = 10.50;
                }
                else
                {
                    priceTicket = 13.50;
                }
            }
            else if (movieName == "Bohemian Rhapsody")
            {
                if (hall == "normal")
                {
                    priceTicket = 7.35;
                }
                else if (hall == "luxury")
                {
                    priceTicket = 9.45;
                }
                else
                {
                    priceTicket = 12.75;
                }
            }
            else if (movieName == "Green Book")
            {
                if (hall == "normal")
                {
                    priceTicket = 8.15;
                }
                else if (hall == "luxury")
                {
                    priceTicket = 10.25;
                }
                else
                {
                    priceTicket = 13.25;
                }
            }
            else
            {
                if (hall == "normal")
                {
                    priceTicket = 8.75;
                }
                else if (hall == "luxury")
                {
                    priceTicket = 11.55;
                }
                else
                {
                    priceTicket = 13.95;
                }
            }


            double total = numTickets * priceTicket;

            Console.WriteLine($"{movieName} -> {total:F2} lv.");


        }
    }
}
