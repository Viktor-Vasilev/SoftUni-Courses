using System;

namespace Izpit_20190615_2._2_Movie_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeSnimki = int.Parse(Console.ReadLine());
            int numSceni = int.Parse(Console.ReadLine());
            int timeScena = int.Parse(Console.ReadLine());

            double podgotovka = timeSnimki * 1.0 * 0.15;

            double timeMovie = numSceni * timeScena;

            double allTime = podgotovka + timeMovie;

            if (timeSnimki >= allTime)
            {
                double ostatyk = Math.Round(timeSnimki - allTime);
                Console.WriteLine($"You managed to finish the movie on time! You have {ostatyk} minutes left!");
            }
            else if (allTime > timeSnimki)
            {
                double nedostig = Math.Round(allTime - timeSnimki);
                Console.WriteLine($"Time is up! To complete the movie you need {nedostig} minutes.");
            }


        }
    }
}
