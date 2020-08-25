using System;

namespace Izpit_20190502_5._Division_Without_Remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int group2 = 0;
            int group3 = 0;
            int group4 = 0;

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    group2++;
                }
                if (number % 3 == 0)
                {
                    group3++;
                }
                if (number % 4 == 0)
                {
                    group4++;
                }

            }

            double percentGroup2 = group2 * 1.0 / n * 100;
            double percentGroup3 = group3 * 1.0 / n * 100;
            double percentGroup4 = group4 * 1.0 / n * 100;

            Console.WriteLine($"{percentGroup2:F2}%");
            Console.WriteLine($"{percentGroup3:F2}%");
            Console.WriteLine($"{percentGroup4:F2}%");


        }
    }
}
