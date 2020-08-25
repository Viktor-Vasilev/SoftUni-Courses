using System;

namespace _04._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int group1 = 0;
            int group2 = 0;
            int group3 = 0;
            int group4 = 0;
            int group5 = 0;

            for (int number = 1; number <= n; number++)
            {
                int value = int.Parse(Console.ReadLine());

                if (value < 200)
                {
                    group1++;
                }
                else if (value >= 200 && value <= 399)
                {
                    group2++;
                }
                else if (value > 399 && value <= 599)
                {
                    group3++;
                }
                else if (value > 599 && value <= 799)
                {
                    group4++;
                }
                else
                {
                    group5++;
                }

            }


            double percentGroup1 = group1 * 1.0 / n * 100;
            double percentGroup2 = group2 * 1.0 / n * 100;
            double percentGroup3 = group3 * 1.0 / n * 100;
            double percentGroup4 = group4 * 1.0 / n * 100;
            double percentGroup5 = group5 * 1.0 / n * 100;



            Console.WriteLine($"{percentGroup1:F2}%");
            Console.WriteLine($"{percentGroup2:F2}%");
            Console.WriteLine($"{percentGroup3:F2}%");
            Console.WriteLine($"{percentGroup4:F2}%");
            Console.WriteLine($"{percentGroup5:F2}%");
        }
    }
}
