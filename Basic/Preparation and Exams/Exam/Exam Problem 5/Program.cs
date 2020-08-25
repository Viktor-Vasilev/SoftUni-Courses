using System;

namespace Exam_Problem_5
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());

            int counterSuitcases = 0;

            while (capacity > 0)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    Console.WriteLine($"Congratulations! All suitcases are loaded!");
                    break;
                }

                double volumeCurrentSuitCase = double.Parse(command);

                counterSuitcases++;

                if (counterSuitcases % 3 == 0)
                {
                    volumeCurrentSuitCase *= 1.10;
                }

                capacity -= volumeCurrentSuitCase;

            }

            if (capacity < 0)
            {
                counterSuitcases--;
                Console.WriteLine($"No more space!");
            }

            Console.WriteLine($"Statistic: {counterSuitcases} suitcases loaded.");

        }
    }
}
