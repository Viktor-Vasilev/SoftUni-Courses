using System;

namespace Izpit_20190309_5._1_Fitness_Centre
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCustomers = int.Parse(Console.ReadLine());

            int groupBack = 0;
            int groupChest = 0;
            int groupLegs = 0;
            int groupAbs = 0;
            int groupProteinShake = 0;
            int groupProteinBar = 0;

            for (int i = 1; i <= numCustomers; i++)
            {
                string typeOfGroup = Console.ReadLine();

                if (typeOfGroup == "Back")
                {
                    groupBack++;
                }
                else if (typeOfGroup == "Chest")
                {
                    groupChest++;
                }
                if (typeOfGroup == "Legs")
                {
                    groupLegs++;
                }
                else if (typeOfGroup == "Abs")
                {
                    groupAbs++;
                }
                else if (typeOfGroup == "Protein shake")
                {
                    groupProteinShake++;
                }
                else if (typeOfGroup == "Protein bar")
                {
                    groupProteinBar++;
                }
            }

            int groupTraining = groupBack + groupChest + groupLegs + groupAbs;
            int groupProtein = groupProteinBar + groupProteinShake;

            double percentGroupTraining = groupTraining * 1.0 / numCustomers * 100;
            double percentGroupProtein = groupProtein * 1.0 / numCustomers * 100;

            Console.WriteLine($"{groupBack} - back");
            Console.WriteLine($"{groupChest} - chest");
            Console.WriteLine($"{groupLegs} - legs");
            Console.WriteLine($"{groupAbs} - abs");
            Console.WriteLine($"{groupProteinShake} - protein shake");
            Console.WriteLine($"{groupProteinBar} - protein bar");
            Console.WriteLine($"{percentGroupTraining:F2}% - work out");
            Console.WriteLine($"{percentGroupProtein:F2}% - protein");
            
        }
    }
}
