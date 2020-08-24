using System;

namespace _05._Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int neededHours = int.Parse(Console.ReadLine());
            int availableDays = int.Parse(Console.ReadLine());
            int numberOfEmployes = int.Parse(Console.ReadLine());

            double workingHours = availableDays * 8 * 0.9;
            // Console.WriteLine( workingHours);
            double additionalHours = availableDays * numberOfEmployes * 2;
            // Console.WriteLine(additionalHours);
            double realHours = Math.Floor(workingHours + additionalHours);
            // Console.WriteLine(realHours);
            if (realHours >= neededHours)
            {
                Console.WriteLine($"Yes!{realHours - neededHours} hours left.");
            }
            else if (realHours < neededHours)
            {
                Console.WriteLine($"Not enough time!{neededHours - realHours} hours needed.");
            }
        }
    }
}
