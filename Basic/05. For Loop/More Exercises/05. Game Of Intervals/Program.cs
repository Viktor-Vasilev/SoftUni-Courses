using System;

namespace _05._Game_Of_Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int group1 = 0; // From 0 to 9
            int group2 = 0; // From 10 to 19
            int group3 = 0; // From 20 to 29
            int group4 = 0; // From 30 to 39
            int group5 = 0; // From 40 to 50
            int group6 = 0; // Invalid numbers

            double sumAll = 0;

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());


                if (number >= 0 && number < 10)
                {
                    group1++;
                    sumAll = sumAll + (number * 0.20);
                }
                else if (number >= 10 && number < 20)
                {
                    group2++;
                    sumAll = sumAll + (number * 0.30);
                }
                else if (number >= 20 && number < 30)
                {
                    group3++;
                    sumAll = sumAll + (number * 0.40);
                }
                else if (number >= 30 && number < 40)
                {
                    group4++;
                    sumAll = sumAll + 50;
                }
                else if (number >= 40 && number <= 50)
                {
                    group5++;
                    sumAll = sumAll + 100;
                }
                else if (number < 0 || number > 50)
                {
                    group6++;
                    sumAll = sumAll * 1.0 / 2;
                }

            }

            double percentGroup1 = group1 * 1.0 / n * 100;
            double percentGroup2 = group2 * 1.0 / n * 100;
            double percentGroup3 = group3 * 1.0 / n * 100;
            double percentGroup4 = group4 * 1.0 / n * 100;
            double percentGroup5 = group5 * 1.0 / n * 100;
            double percentGroup6 = group6 * 1.0 / n * 100;

            Console.WriteLine($"{sumAll:F2}");
            Console.WriteLine($"From 0 to 9: {percentGroup1:F2}%");
            Console.WriteLine($"From 10 to 19: {percentGroup2:F2}%");
            Console.WriteLine($"From 20 to 29: {percentGroup3:F2}%");
            Console.WriteLine($"From 30 to 39: {percentGroup4:F2}%");
            Console.WriteLine($"From 40 to 50: {percentGroup5:F2}%");
            Console.WriteLine($"Invalid numbers: {percentGroup6:F2}%");
        }
    }
}
