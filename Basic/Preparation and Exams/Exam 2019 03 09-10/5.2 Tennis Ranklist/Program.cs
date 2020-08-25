using System;

namespace Izpit_20190309_5._2_Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numTournaments = int.Parse(Console.ReadLine());
            int StartingPoints = int.Parse(Console.ReadLine());

            int wonPoints = 0;
            int titlesWon = 0;

            for (int i = 1; i <= numTournaments; i++)
            {
                string etap = Console.ReadLine();

                if (etap == "W")
                {
                    wonPoints += 2000;
                    titlesWon++;
                }
                else if (etap == "F")
                {
                    wonPoints += 1200;
                }
                else
                {
                    wonPoints += 720;
                }
            }
            double finalPoints = StartingPoints + wonPoints;

            double averagePoints = Math.Floor(wonPoints * 1.0 / numTournaments);

            double percentWonTournaments = titlesWon * 1.0 / numTournaments * 100;

            Console.WriteLine($"Final points: {finalPoints}");
            Console.WriteLine($"Average points: {averagePoints}");
            Console.WriteLine($"{percentWonTournaments:F2}%");

        }
    }
}
