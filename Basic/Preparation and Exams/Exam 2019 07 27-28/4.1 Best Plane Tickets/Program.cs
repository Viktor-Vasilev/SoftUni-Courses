using System;

namespace Izpit_20190727_4._1_Best_Plane_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {

            int minWait = int.MaxValue;

            string bestTicket = "";

            double bestPrice = double.MaxValue;

            string planeTicket = Console.ReadLine();

            while (planeTicket != "End")
            {
                double currentTicketPrice = double.Parse(Console.ReadLine());
                int currentIdleTime = int.Parse(Console.ReadLine());

                currentTicketPrice *= 1.96;

                if (currentIdleTime < minWait)
                {
                    bestTicket = planeTicket;
                    bestPrice = currentTicketPrice;
                    minWait = currentIdleTime;
                }

                planeTicket = Console.ReadLine();
            }

            if (planeTicket == "End")
            {
                int hoursIdle = minWait / 60;
                int minutesIdle = minWait % 60;

                Console.WriteLine($"Ticket found for flight {bestTicket} costs {bestPrice:F2} leva with {hoursIdle}h {minutesIdle}m stay");
            }

        }
    }
}
