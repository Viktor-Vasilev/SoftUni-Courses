using System;

namespace Izpit_20190706_6._1_Name_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();

            string currentLeader = "";

            int bestPoints = 0;

            while (playerName != "Stop")
            {
                int currentPlayerPoints = 0;

                for (int letters = 0; letters < playerName.Length; letters++)
                {
                    int points = int.Parse(Console.ReadLine());

                    if (points == playerName[letters])
                    {
                        currentPlayerPoints += 10;
                    }
                    else
                    {
                        currentPlayerPoints += 2;
                    }

                }

                if (currentPlayerPoints >= bestPoints)
                {
                    bestPoints = currentPlayerPoints;
                    currentLeader = playerName;
                }

                playerName = Console.ReadLine();
            }

            if (playerName == "Stop")
            {
                Console.WriteLine($"The winner is {currentLeader} with {bestPoints} points!");
            }

        }
    }
}
