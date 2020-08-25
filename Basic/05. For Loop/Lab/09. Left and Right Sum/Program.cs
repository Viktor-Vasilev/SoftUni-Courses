using System;

namespace _09._Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < n; i++)
            {
                int number1 = int.Parse(Console.ReadLine());
                leftSum += number1;
            }

            for (int i = 0; i < n; i++)
            {
                int number2 = int.Parse(Console.ReadLine());
                rightSum += number2;
            }

            int difference = Math.Abs(leftSum - rightSum);

            if (difference == 0)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {difference}");
            }
        }
    }
}
