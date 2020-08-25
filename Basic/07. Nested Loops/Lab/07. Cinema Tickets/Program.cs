using System;

namespace _07._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();

            int allTicketsCounter = 0;

            int studentTicketCounter = 0;
            int standartTicketCounter = 0;
            int kidTicketCounter = 0;

            while (movieName != "Finish")
            {
                int freeSeats = int.Parse(Console.ReadLine());

                string ticketType = Console.ReadLine();

                int counterCurrentMovie = 0;

                while (ticketType != "End")
                {
                    counterCurrentMovie++;

                    if (ticketType == "student")
                    {
                        studentTicketCounter++;
                    }
                    if (ticketType == "standard")
                    {
                        standartTicketCounter++;
                    }
                    if (ticketType == "kid")
                    {
                        kidTicketCounter++;
                    }

                    if (counterCurrentMovie == freeSeats)
                    {
                        break;
                    }

                    ticketType = Console.ReadLine();
                }

                allTicketsCounter += counterCurrentMovie;

                double percentForMovie = counterCurrentMovie * 1.0 / freeSeats * 100;

                Console.WriteLine($"{movieName} - {percentForMovie:F2}% full.");

                movieName = Console.ReadLine();
            }

            double percentStudentTickets = studentTicketCounter * 1.0 / allTicketsCounter * 100;
            double percentStandartTickets = standartTicketCounter * 1.0 / allTicketsCounter * 100;
            double percentKidTickets = kidTicketCounter * 1.0 / allTicketsCounter * 100;

            Console.WriteLine($"Total tickets: {allTicketsCounter}");
            Console.WriteLine($"{percentStudentTickets:F2}% student tickets.");
            Console.WriteLine($"{percentStandartTickets:F2}% standard tickets.");
            Console.WriteLine($"{percentKidTickets:F2}% kids tickets.");
        }
    }
}
