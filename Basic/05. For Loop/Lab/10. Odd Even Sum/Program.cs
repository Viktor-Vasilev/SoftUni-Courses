using System;

namespace _10._Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int evenSum = 0;
            int oddSum = 0;

            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    int num1 = int.Parse(Console.ReadLine());
                    evenSum += num1;
                }
                else
                {
                    int num2 = int.Parse(Console.ReadLine());
                    oddSum += num2;
                }
            }

            int differens = Math.Abs(evenSum - oddSum);

            if (differens == 0)
            {
                Console.WriteLine($"Yes");
                Console.WriteLine($"Sum = {evenSum}");
            }
            else
            {
                Console.WriteLine($"No");
                Console.WriteLine($"Diff = {differens}");
            }
        }
    }
}
