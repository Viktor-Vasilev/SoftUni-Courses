using System;

namespace _07._Football_League
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            int numberOfFans = int.Parse(Console.ReadLine());

            int groupA = 0;
            int groupB = 0;
            int groupV = 0;
            int groupG = 0;

            for (int i = 1; i <= numberOfFans; i++)
            {
                string sector = Console.ReadLine();

                if (sector == "A")
                {
                    groupA++;
                }
                else if (sector == "B")
                {
                    groupB++;
                }
                else if (sector == "V")
                {
                    groupV++;
                }
                else
                {
                    groupG++;
                }
            }

            double percentGroupA = (groupA * 1.0 / numberOfFans) * 100;
            double percentGroupB = (groupB * 1.0 / numberOfFans) * 100;
            double percentGroupV = (groupV * 1.0 / numberOfFans) * 100;
            double percentGroupG = (groupG * 1.0 / numberOfFans) * 100;

            double percentAll = (numberOfFans * 1.0 / capacity) * 100;

            Console.WriteLine($"{percentGroupA:F2}%");
            Console.WriteLine($"{percentGroupB:F2}%");
            Console.WriteLine($"{percentGroupV:F2}%");
            Console.WriteLine($"{percentGroupG:F2}%");
            Console.WriteLine($"{percentAll:F2}%");
        }
    }
}
