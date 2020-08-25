using System;

namespace _20191102_Group_1_Biscuits_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitPerDayPerWorker = int.Parse(Console.ReadLine());
            int numWorkers = int.Parse(Console.ReadLine());
            int otherFactoryBiscuits = int.Parse(Console.ReadLine());

            double totalBiscuit = 0;

            for (int i = 1; i <= 30; i++)
            {
                if(i % 3 == 0)
                {
                    totalBiscuit += Math.Floor((biscuitPerDayPerWorker * numWorkers) * 0.75);
                }
                else
                {
                    totalBiscuit += biscuitPerDayPerWorker * numWorkers;
                }

            }

            Console.WriteLine($"You have produced {totalBiscuit} biscuits for the past month.");

            double percentage = Math.Abs((totalBiscuit - otherFactoryBiscuits) / otherFactoryBiscuits) * 100;

            if(totalBiscuit > otherFactoryBiscuits)
            {
                Console.WriteLine($"You produce {percentage:f2} percent more biscuits.");
            }
            else
            {
                Console.WriteLine($"You produce {percentage:f2} percent less biscuits.");
            }

        }
    }
}
