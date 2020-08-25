using System;

namespace _06._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int num = 0;

            for (int i = 1111; i <= 9999; i++)
            {
                int pos4 = i % 10;
                num = i / 10;

                int pos3 = num % 10;
                num = num / 10;

                int pos2 = num % 10;
                num = num / 10;

                int pos1 = num % 10;

                if (pos1 != 0 && pos2 != 0 && pos3 != 0 && pos4 != 0)
                {
                    if (n % pos1 == 0 && n % pos2 == 0 && n % pos3 == 0 && n % pos4 == 0)
                    {
                        Console.Write($"{pos1}{pos2}{pos3}{pos4} ");
                    }
                }
            }
        }
    }
}
