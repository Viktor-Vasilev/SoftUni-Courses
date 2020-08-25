using System;

namespace Izpit_20190420_4._1_Easter_Bake
{
    class Program
    {
        static void Main(string[] args)
        {
            int numBakes = int.Parse(Console.ReadLine());

            int countSugar = 0;
            int countFlower = 0;

            int currentMaxSugar = int.MinValue;
            int currentMaxFlower = int.MinValue;

            for (int i = 1; i <= numBakes; i++)
            {
                int volumeSugar = int.Parse(Console.ReadLine());
                int volumeFlower = int.Parse(Console.ReadLine());

                countSugar += volumeSugar;
                countFlower += volumeFlower;

                if (volumeSugar > currentMaxSugar)
                {
                    currentMaxSugar = volumeSugar;
                }

                if (volumeFlower > currentMaxFlower)
                {
                    currentMaxFlower = volumeFlower;
                }                

            }

            double numPacketsSugar = Math.Ceiling(countSugar * 1.0/ 950);
            double numPacketsFlower = Math.Ceiling(countFlower * 1.0/ 750);

            Console.WriteLine($"Sugar: {numPacketsSugar}");
            Console.WriteLine($"Flour: {numPacketsFlower}");
            Console.WriteLine($"Max used flour is {currentMaxFlower} grams, max used sugar is {currentMaxSugar} grams.");

        }
    }
}
