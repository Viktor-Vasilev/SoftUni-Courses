using System;

namespace Izpit_20190706_5._1_Football_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            int numGames = int.Parse(Console.ReadLine());

            int gameWon = 0;
            int gameDrawn = 0;
            int gameLost = 0;

            int pointsWon = 0;

            if (numGames == 0)
            {
                Console.WriteLine($"{teamName} hasn't played any games during this season.");
            }

            else
            {
                for (int i = 1; i <= numGames; i++)
                {
                    string result = Console.ReadLine();
                    if (result == "W")
                    {
                        gameWon++;
                        pointsWon += 3;
                    }
                    else if (result == "D")
                    {
                        gameDrawn++;
                        pointsWon += 1;

                    }
                    else
                    {
                        gameLost++;
                    }

                }

                double percentWonGames = gameWon * 1.0 / numGames * 100;

                Console.WriteLine($"{teamName} has won {pointsWon} points during this season.");
                Console.WriteLine($"Total stats:");
                Console.WriteLine($"## W: {gameWon}");
                Console.WriteLine($"## D: {gameDrawn}");
                Console.WriteLine($"## L: {gameLost}");
                Console.WriteLine($"Win rate: {percentWonGames:F2}%");



            }
        }
    }
}
