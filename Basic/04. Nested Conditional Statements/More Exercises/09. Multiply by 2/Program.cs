using System;

namespace _09._Multiply_by_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            if (number < 0)
            {
                Console.WriteLine("Negative number!");
                return;
            }
            else
            {
                Console.WriteLine($"Result: {number * 2:F2}");
            }

        }
    }
}
