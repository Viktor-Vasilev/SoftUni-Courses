using System;

namespace Izpit_20190420_6._1_Easter_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCakes = int.Parse(Console.ReadLine());
            string currentChefLeader = "";
            int bestPoints = 0;

            for (int i = 0; i < numCakes; i++)
            {
                string chefName = Console.ReadLine();
                string currentPoints = Console.ReadLine();
                int pointsCurrentChef = 0;

                while (currentPoints != "Stop")
                {
                    pointsCurrentChef += int.Parse(currentPoints);
                    currentPoints = Console.ReadLine();
                }

                Console.WriteLine($"{chefName} has {pointsCurrentChef} points.");

                if (pointsCurrentChef > bestPoints)
                {
                    bestPoints = pointsCurrentChef;
                    currentChefLeader = chefName;
                    Console.WriteLine($"{currentChefLeader} is the new number 1!");
                }
            }
            Console.WriteLine($"{currentChefLeader} won competition with {bestPoints} points!");

        }
    }
}
