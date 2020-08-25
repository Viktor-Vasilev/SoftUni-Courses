using System;

namespace Izpit_20190615_3._1_Film_Premiere
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            string pack = Console.ReadLine();
            int numberOfTickets = int.Parse(Console.ReadLine());

            double priceFor1Ticket = 0;

            if (movieName == "John Wick")
            {
                if (pack == "Drink")
                {
                    priceFor1Ticket = 12;
                }
                else if (pack == "Popcorn")
                {
                    priceFor1Ticket = 15;
                }
                else
                {
                    priceFor1Ticket = 19;
                }
            }
            else if (movieName == "Star Wars")
            {
                if (pack == "Drink")
                {
                    priceFor1Ticket = 18;
                }
                else if (pack == "Popcorn")
                {
                    priceFor1Ticket = 25;
                }
                else
                {
                    priceFor1Ticket = 30;
                }
            }
            else
            {
                if (pack == "Drink")
                {
                    priceFor1Ticket = 9;
                }
                else if (pack == "Popcorn")
                {
                    priceFor1Ticket = 11;
                }
                else
                {
                    priceFor1Ticket = 14;
                }
            }

            double total = numberOfTickets * priceFor1Ticket;

            if (movieName == "Star Wars" && numberOfTickets >= 4)
            {
                total = total * 0.70;
            }

            if (movieName == "Jumanji" && numberOfTickets == 2)
            {
                total = total * 0.85;
            }

            Console.WriteLine($"Your bill is {total:F2} leva.");
        }
    }
}
