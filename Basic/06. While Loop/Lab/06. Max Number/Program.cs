using System;

namespace _06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int currentMax = int.MinValue;

            int currentNumber = 0;

            for (int i = 1; i <= n; i++)
            {
                currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber > currentMax)
                {
                    currentMax = currentNumber;
                }
            }

            Console.WriteLine(currentMax);




        }
    }
}
