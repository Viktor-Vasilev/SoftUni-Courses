using System;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberSnowballs = int.Parse(Console.ReadLine());

            double bestsnowballValue = double.MinValue;

            double snowballValue = 0;
            int bestsnowballSnow = 0;
            int bestsnowballTime = 0;
            int bestsnowballQuality = 0;

            for (int currentSnowball = 1; currentSnowball <= numberSnowballs; currentSnowball++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                snowballValue = Math.Pow((snowballSnow * 1.0 / snowballTime), snowballQuality);

                if (snowballValue >= bestsnowballValue)
                {
                    bestsnowballValue = snowballValue;
                    bestsnowballSnow = snowballSnow;
                    bestsnowballTime = snowballTime;
                    bestsnowballQuality = snowballQuality;
                }

            }

            Console.WriteLine($"{bestsnowballSnow} : {bestsnowballTime} = {bestsnowballValue} ({bestsnowballQuality})");

        }
    }
}
