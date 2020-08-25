using System;

namespace Izpit_20190615_1._2_Series_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameSerial = Console.ReadLine();
            int numSeasons = int.Parse(Console.ReadLine());
            int numEpisodes = int.Parse(Console.ReadLine());
            double timeFor1EpisodeInMinutes = double.Parse(Console.ReadLine());

            double timeForReklami = timeFor1EpisodeInMinutes * 0.2;
            double totalTimeFor1Episode = timeFor1EpisodeInMinutes + timeForReklami;
            double additionalTimeSpecial = numSeasons * 10;
            double grandTotal = Math.Floor((numSeasons * numEpisodes * totalTimeFor1Episode) + additionalTimeSpecial);
            Console.WriteLine($"Total time needed to watch the {nameSerial} series is {grandTotal} minutes.");


        }
    }
}
