using System;

namespace _08._Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int oddSum = 0;
            int evenSum = 0;

            int maxDiff = 0;

            for (int i = 1; i <= n; i++)
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());

                if (i % 2 != 0)
                {
                    evenSum = num1 + num2;
                }
                else
                {
                    oddSum = num1 + num2;
                }

                if (oddSum != evenSum && i > 1)
                {
                    int newDiff = Math.Abs(evenSum - oddSum);
                    if (newDiff >= maxDiff)
                    {
                        maxDiff = newDiff;
                    }

                }


            }

            if (maxDiff == 0)
            {
                Console.WriteLine($"Yes, value={evenSum}");
            }

            else
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
        }
    }
}
