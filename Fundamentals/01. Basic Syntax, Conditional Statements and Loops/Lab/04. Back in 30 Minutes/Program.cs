using System;

namespace _04._Back_in_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int NewTimeInMinutes = hours * 60 + minutes + 30;

            int newTimeHours = NewTimeInMinutes / 60;
            int newTimeMinutes = NewTimeInMinutes % 60;

            if (newTimeHours == 24)
            {
                newTimeHours = 0;
            }

            Console.WriteLine($"{newTimeHours}:{newTimeMinutes:D2}");

            //int hours = int.Parse(Console.ReadLine());
            //int minutes = int.Parse(Console.ReadLine());

            //int newMinutes = minutes + 30;

            //if (newMinutes >= 60)
            //{
            //    newMinutes -= 60;
            //    hours++;
            //}

            //if (hours > 23)
            //{
            //    hours = 0;
            //}

            //Console.WriteLine($"{hours}:{newMinutes:D2}");
        }
    }
}
