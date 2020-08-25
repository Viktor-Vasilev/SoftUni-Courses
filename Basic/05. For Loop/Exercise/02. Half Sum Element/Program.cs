using System;

namespace _02._Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int biggest = int.MinValue;

            int sum = 0;

            for (int number = 1; number <= n; number++)
            {
                int value = int.Parse(Console.ReadLine());
                sum += value;

                if (value > biggest)
                {
                    biggest = value;
                }

            }

            int sumAllOthers = sum - biggest;

            int difference = Math.Abs(sumAllOthers - biggest);

            if (sumAllOthers == biggest)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {biggest}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {difference}");
            }

        }
    }
}
