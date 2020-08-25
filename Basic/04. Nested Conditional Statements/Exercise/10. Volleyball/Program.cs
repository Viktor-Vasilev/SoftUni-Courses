using System;

namespace _10._Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int numWeekendsAtHome = int.Parse(Console.ReadLine());

            double totalWeekends = 48;

            double weekendsInSofia = totalWeekends - numWeekendsAtHome;
            double playsInSofia = weekendsInSofia * 1.0 * 3 / 4;
            double playsInHomeTown = numWeekendsAtHome;
            double playsInHolidays = holidays * 1.0 * 2 / 3;

            double totalPlays = playsInSofia + playsInHomeTown + playsInHolidays;

            if (year == "leap")
            {
                totalPlays = (totalPlays + (totalPlays * 0.15));
            }

            Console.WriteLine($"{Math.Floor(totalPlays)}");
        }
    }
}
