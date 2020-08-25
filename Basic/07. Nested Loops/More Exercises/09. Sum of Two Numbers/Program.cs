using System;

namespace _09._Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int begin = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int num1 = begin; num1 <= finish; num1++)
            {
                for (int num2 = begin; num2 <= finish; num2++)
                {
                    counter++;

                    if (num1 + num2 == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{counter} ({num1} + {num2} = {magicNumber})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
        }
    }
}
