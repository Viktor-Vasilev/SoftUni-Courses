using System;

namespace Izpit_20190615_2._1_Lunch_Break
{
    class Program
    {
        static void Main(string[] args)
        {
            string serialName = Console.ReadLine();
            int timeSerial = int.Parse(Console.ReadLine());
            int timeBreak = int.Parse(Console.ReadLine());

            double timeLunch = (timeBreak * 1.0) / 8; 
            double timeRest = (timeBreak * 1.0) / 4;

            double freeTime = timeBreak - timeLunch - timeRest;

            // Console.WriteLine(freeTime);

            if (timeSerial <= freeTime)
            {
                double leftTime = Math.Ceiling(freeTime - timeSerial);
                Console.WriteLine($"You have enough time to watch {serialName} and left with {leftTime} minutes free time.");
            }
            else if (timeSerial > freeTime)
            {
                double nedostigVreme = Math.Ceiling(timeSerial - freeTime);
                Console.WriteLine($"You don't have enough time to watch {serialName}, you need {nedostigVreme} more minutes.");
            }
        }
    }
}
