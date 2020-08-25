using System;

namespace _07._Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int currentMin = int.MaxValue;

            int currentNumber = 0;

            for (int i = 1; i <= n; i++)
            {
                currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber < currentMin)
                {
                    currentMin = currentNumber;
                }
            }

            Console.WriteLine(currentMin);




        }
    }
}
