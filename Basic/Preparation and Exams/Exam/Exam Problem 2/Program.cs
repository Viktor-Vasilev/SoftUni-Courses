using System;

namespace Exam_Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double metersInSecond = double.Parse(Console.ReadLine());

            double time = (distanceInMeters * metersInSecond) + (Math.Floor(distanceInMeters / 50) * 30);

            if (recordInSeconds <= time)
            {
                Console.WriteLine($"No! He was {time - recordInSeconds:F2} seconds slower.");
            }
            else
            {
                Console.WriteLine($"Yes! The new record is {time:F2} seconds.");
            }
        }
    }
}
