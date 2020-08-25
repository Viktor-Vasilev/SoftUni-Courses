using System;

namespace _20190630_Group_1_Distance_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            long steps = long.Parse(Console.ReadLine());
            decimal lengthOfStep = decimal.Parse(Console.ReadLine());
            long distanceToCover = long.Parse(Console.ReadLine());
            decimal distanceCovered = 0;
            decimal smallStep = 0;

            for (int i = 1; i <= steps; i++)
            {
                if (i % 5 == 0)
                {
                    smallStep = lengthOfStep * 0.70m;
                    distanceCovered += smallStep;
                }
                else
                {
                    distanceCovered += lengthOfStep;
                }
            }

            distanceCovered /= 100;
            decimal percentage = distanceCovered / distanceToCover * 100m;
            Console.WriteLine($"You travelled {percentage:f2}% of the distance!");

        }
    }
}
