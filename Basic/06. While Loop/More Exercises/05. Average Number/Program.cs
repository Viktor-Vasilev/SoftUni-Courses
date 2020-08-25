using System;

namespace _05._Average_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumNumber = 0;

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sumNumber += number;
            }

            double srednoAritm = sumNumber * 1.0 / n;

            Console.WriteLine($"{srednoAritm:F2}");


        }
    }
}
