using System;

namespace Podgotovka_za_izpit_201912_3._Snooker_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string stage = Console.ReadLine();
            string typeOfTicket = Console.ReadLine();
            int numberOfTickets = int.Parse(Console.ReadLine());
            string picture = Console.ReadLine();

            double ticketPrice = 0;

            if (stage == "Quarter final" && typeOfTicket == "Standard")
            {
                ticketPrice = 55.50;
            }
            if (stage == "Quarter final" && typeOfTicket == "Premium")
            {
                ticketPrice = 105.20;
            }
            if (stage == "Quarter final" && typeOfTicket == "VIP")
            {
                ticketPrice = 118.90;
            }
            if (stage == "Semi final" && typeOfTicket == "Standard")
            {
                ticketPrice = 75.88;
            }
            if (stage == "Semi final" && typeOfTicket == "Premium")
            {
                ticketPrice = 125.22;
            }
            if (stage == "Semi final" && typeOfTicket == "VIP")
            {
                ticketPrice = 300.40;
            }
            if (stage == "Final" && typeOfTicket == "Standard")
            {
                ticketPrice = 110.10;
            }
            if (stage == "Final" && typeOfTicket == "Premium")
            {
                ticketPrice = 160.66;
            }
            if (stage == "Final" && typeOfTicket == "VIP")
            {
                ticketPrice = 400.00;
            }

            double total = ticketPrice * numberOfTickets;

            if (total > 4000)
            {
                total = total * 0.75;
            }

            else if ((total > 2500 && total <= 4000) && picture == "Y")
            {
                total = (total * 0.90) + (numberOfTickets * 40);
            }
            else if ((total > 2500 && total <= 4000) && picture == "N")
            {
                total = total * 0.90;
            }

            else if (total < 2500 && picture == "Y")
            {
                total = (total + (numberOfTickets * 40));
            }
            else if (total < 2500 && picture == "N")
            {
                total = total;
            }

            Console.WriteLine($"{total:F2}");






        }
    }
}
