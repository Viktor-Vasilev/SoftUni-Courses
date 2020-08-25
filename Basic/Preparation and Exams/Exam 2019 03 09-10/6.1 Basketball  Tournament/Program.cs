using System;

namespace Izpit_20190309_6._1_Basketball__Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string tourName = Console.ReadLine();

            int counterGamesAll = 0;

            int wins = 0;

            int losses = 0;

            while (tourName != "End of tournaments")
            {
                int numMatches = int.Parse(Console.ReadLine());

                int counterGamesCurrentTour = 0;

                while (numMatches > 0)
                {
                    int pointsIn = int.Parse(Console.ReadLine());
                    int pointsOut = int.Parse(Console.ReadLine());

                    numMatches--;
                    counterGamesCurrentTour++;
                    counterGamesAll++;

                    if (pointsIn > pointsOut)
                    {
                        Console.WriteLine($"Game {counterGamesCurrentTour} of tournament {tourName}: win with {pointsIn - pointsOut} points.");
                        wins++;
                    }
                    if (pointsIn < pointsOut)
                    {
                        Console.WriteLine($"Game {counterGamesCurrentTour} of tournament {tourName}: lost with {pointsOut - pointsIn} points.");
                        losses++;
                    }

                }
                tourName = Console.ReadLine();
            }

            if (tourName == "End of tournaments")
            {
                double percentWon = wins * 1.0 / counterGamesAll * 100;
                double percentLost = losses * 1.0 / counterGamesAll * 100;

                Console.WriteLine($"{percentWon:F2}% matches win");
                Console.WriteLine($"{percentLost:F2}% matches lost");
            }

        }
    }
}
