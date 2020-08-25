using System;

namespace _05._Divide_Without_Remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int group1 = 0;
            int group2 = 0;
            int group3 = 0;

            for (int number = 1; number <= n; number++)
            {
                int value = int.Parse(Console.ReadLine());

                if (value % 2 == 0)
                {
                    group1++;
                }

                if (value % 3 == 0)
                {
                    group2++;
                }

                if (value % 4 == 0)
                {
                    group3++;
                }

            }

            double percentGroup1 = group1 * 1.0 / n * 100;
            double percentGroup2 = group2 * 1.0 / n * 100;
            double percentGroup3 = group3 * 1.0 / n * 100;


            Console.WriteLine($"{percentGroup1:F2}%");
            Console.WriteLine($"{percentGroup2:F2}%");
            Console.WriteLine($"{percentGroup3:F2}%");
        }
    }
}
