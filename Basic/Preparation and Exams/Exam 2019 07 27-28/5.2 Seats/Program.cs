using System;

namespace Izpit_20190727_5._2_Seats
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfTickets = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numOfTickets; i++)
            {
                string ticket = Console.ReadLine();
                //int ticketToNum = int.Parse(ticket.ToString());

                char firstDigit = ticket[0];
                char secondDigit = ticket[1];
                char thirdDigit = ticket[2];
                char fourthDigit = ticket[3];

                bool condition = firstDigit >= 'A' && firstDigit <= 'Z';

                if (ticket.Length == 4) // Проверяваме дължината на съответния билет
                {
                    if (condition)
                    {
                        Console.WriteLine($"Seat decoded: {firstDigit}{secondDigit}{thirdDigit}");
                    }

                    else
                    {
                        Console.WriteLine($"Seat decoded: {fourthDigit}{secondDigit}{thirdDigit}");
                    }
                }

                else if (ticket.Length == 5 || ticket.Length == 6) // Проверяваме дължината на съответния билет
                {
                    //char digit = char.Parse(secondDigit.ToString());
                    var ASCIIDigit = (int)secondDigit; // взимаме ASCII стойността на втория символ
                    Console.WriteLine($"Seat decoded: {firstDigit}{ASCIIDigit}");
                }





            }    }
    }
}
