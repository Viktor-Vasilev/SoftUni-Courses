using System;

namespace Izpit_20190309_6._2_High_Jump
{
    class Program
    {
        static void Main(string[] args)
        {
            int goalHeight = int.Parse(Console.ReadLine());

            int startingHeight = goalHeight - 30;

            int totalJumps = 0;

            bool badJumps = false;

            while (!badJumps)
            {
                startingHeight += 5;
                badJumps = true;
                int jumpingHigh = 0;
                for (int i = 1; i <= 3; i++)
                {
                    totalJumps++;
                    jumpingHigh = int.Parse(Console.ReadLine());
                    if (jumpingHigh > startingHeight)
                    {
                        if (startingHeight >= goalHeight)
                        {
                            Console.WriteLine($"Tihomir succeeded, he jumped over {startingHeight}cm after {totalJumps} jumps.");
                            return;
                        }
                        badJumps = false;
                        break;
                    }
                }
            }
            Console.WriteLine($"Tihomir failed at {startingHeight}cm after {totalJumps} jumps.");
        }
    }
}
