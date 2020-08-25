using System;

namespace _04._Print_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numStart = int.Parse(Console.ReadLine());
            int numEnd = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = numStart; i <= numEnd; i++)
            {
                Console.Write(i + " " );

                sum += i;              
            }

            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
