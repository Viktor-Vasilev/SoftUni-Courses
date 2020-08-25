using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int currentNum = 1; currentNum <= number; currentNum++)
            {
                int sum = 0;

                int digits = currentNum;

                while (digits > 0)
                {
                    sum += digits % 10;
                    digits /= 10;
                }

                bool isValid = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine($"{currentNum} -> {isValid}");

                sum = 0;

            }
        }
    }
}
