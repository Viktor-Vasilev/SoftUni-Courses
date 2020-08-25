using System;

namespace Izpit_20190727_5._1_Cruise_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();
            int numGames = int.Parse(Console.ReadLine());

            double volleyballPoints = 0;
            int volleyballGames = 0;           
            double tennisPoints = 0;
            int tennisGames = 0;
            double badmintonPoints = 0;
            int badmintonGames = 0;

            for (int i = 1; i <= numGames; i++)
            {
                string gameName = Console.ReadLine();
                int pointsGiven = int.Parse(Console.ReadLine());

                if (gameName == "volleyball")
                {
                    volleyballPoints += pointsGiven * 1.07;
                    volleyballGames++;
                }
                if (gameName == "tennis")
                {
                    tennisPoints += pointsGiven * 1.05;
                    tennisGames++;
                }
                if (gameName == "badminton")
                {
                    badmintonPoints += pointsGiven * 1.02;
                    badmintonGames++;
                }
    
            }
            double totalPoints = Math.Floor(volleyballPoints + tennisPoints + badmintonPoints);

            double srednoAritmVolleyball = Math.Floor(volleyballPoints * 1.0 / volleyballGames);
            double srednoAritmTennis = Math.Floor(tennisPoints * 1.0 / tennisGames);
            double srednoAritmBadminton = Math.Floor(badmintonPoints * 1.0 / badmintonGames);

            if (srednoAritmVolleyball >= 75 && srednoAritmTennis >= 75 && srednoAritmBadminton >=75)
            {
                Console.WriteLine($"Congratulations, {playerName}! You won the cruise games with {totalPoints} points.");
            }
            else
            {
                Console.WriteLine($"Sorry, {playerName}, you lost. Your points are only {totalPoints}.");
            }

        }
    }
}
