using System;

namespace _08._Secret_Door_s_Lock
{
    class Program
    {
        static void Main(string[] args)
        {
            int hundredsEnd = int.Parse(Console.ReadLine());
            int decimalEnd = int.Parse(Console.ReadLine());
            int singleEnd = int.Parse(Console.ReadLine());

            for (int i = 1; i <= hundredsEnd; i++)
            {
                for (int j = 1; j <= decimalEnd; j++)
                {
                    for (int k = 1; k <= singleEnd; k++)
                    {
                        if (i % 2 == 0 && k % 2 == 0)
                        {
                            if (j == 2 || j == 3 || j == 5 || j == 7)
                            {
                                Console.WriteLine($"{i} {j} {k}");
                            }
                        }
                    }
                }
            }
        }
    }
}
