using System;

namespace _07._World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double timeInSecondsFor1Meter = double.Parse(Console.ReadLine());
            double IvansTime = distanceInMeters * timeInSecondsFor1Meter;
            double dobavenoVreme = Math.Floor(distanceInMeters / 15) * 12.5;
            // Console.WriteLine(dobavenoVreme);
            double IvansNewTime = IvansTime + dobavenoVreme;
            if (IvansNewTime >= recordInSeconds)
            {
                Console.WriteLine($"No, he failed! He was {IvansNewTime - recordInSeconds:F2} seconds slower.");
            }
            else if (IvansNewTime < recordInSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {IvansNewTime:F2} seconds.");
            }
        }
    }
}
