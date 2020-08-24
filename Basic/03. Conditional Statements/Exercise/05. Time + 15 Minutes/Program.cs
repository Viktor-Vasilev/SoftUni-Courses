using System;

namespace _05._Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minute = int.Parse(Console.ReadLine());
            int allMinutes = (hour * 60) + minute + 15;
            int newHours = allMinutes / 60;
            int newMinutes = allMinutes % 60;
            if (newHours == 24)
            {
                newHours = 0;
            }

            Console.WriteLine($"{newHours}:{newMinutes:D2}");
        }
    }
}
