using System;

namespace _01._Match_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            double numOfPeople = double.Parse(Console.ReadLine());

            double priceTransport = 0;
            double priceTickets = 0;

            if (numOfPeople < 5)
            {
                priceTransport = budget * 0.75;

            }
            else if (numOfPeople >= 5 && numOfPeople < 10)
            {
                priceTransport = budget * 0.60;

            }
            else if (numOfPeople >= 10 && numOfPeople < 25)
            {
                priceTransport = budget * 0.50;

            }
            else if (numOfPeople >= 25 && numOfPeople < 50)
            {
                priceTransport = budget * 0.40;

            }
            else if (numOfPeople >= 50)
            {
                priceTransport = budget * 0.25;

            }


            if (category == "VIP")
            {
                priceTickets = numOfPeople * 499.99;
            }
            else
            {
                priceTickets = numOfPeople * 249.99;
            }

            double leftMoneyForTickets = (budget - priceTransport);

            if (leftMoneyForTickets >= priceTickets)
            {
                Console.WriteLine($"Yes! You have {leftMoneyForTickets - priceTickets:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {priceTickets - leftMoneyForTickets:F2} leva.");
            }

        }
    }
}
