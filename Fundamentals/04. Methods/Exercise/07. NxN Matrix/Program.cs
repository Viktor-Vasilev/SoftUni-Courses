using System;

namespace _2.Ex_07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintNxNMAtrix(n);

        }
        public static void PrintNxNMAtrix(int n)
        {
            for (int i = 0; i < n; i++)
            {

                for (int k = 0; k < n; k++)
                {
                    Console.Write($"{n} ");
                }

                Console.WriteLine();

            }
        }

    }
}
