using System;

namespace Izpit_20190615_1._1_Movie_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            int numDays = int.Parse(Console.ReadLine());
            int numTickets = int.Parse(Console.ReadLine());
            double priceTicket = double.Parse(Console.ReadLine());
            int percentForTheater = int.Parse(Console.ReadLine());

            double income = numDays * numTickets * priceTicket;
            double feeForTheater = (percentForTheater * income) / 100;
            double total = income - feeForTheater;
            Console.WriteLine($"The profit from the movie {movieName} is {total:F2} lv.");


        }
    }
}
