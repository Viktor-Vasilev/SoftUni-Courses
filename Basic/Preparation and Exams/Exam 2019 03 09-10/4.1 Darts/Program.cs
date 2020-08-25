using System;

namespace Izpit_20190420_4._1_Darts
{
    class Program
    {
        static void Main(string[] args)
        {
           string playerName = Console.ReadLine();

           int totalPoints = 301;

           int goodShots = 0;
           int badShots = 0;
            
            while (totalPoints != 0)
            {
                string command = Console.ReadLine();
                if (command == "Retire")
                {
                    break;
                }

                int hitpoints = int.Parse(Console.ReadLine());
                if (command == "Double")
                {
                    hitpoints *= 2;
                }
                if (command == "Triple")
                {
                    hitpoints *= 3;
                }

                if (totalPoints >= hitpoints)
                {
                    totalPoints -= hitpoints;
                    goodShots++;
                }
                else
                {
                    badShots++;
                }
            }
            
            if (totalPoints == 0)
            {
                Console.WriteLine($"{playerName} won the leg with {goodShots} shots.");
            }
            else
            {
                Console.WriteLine($"{playerName} retired after {badShots} unsuccessful shots.");
            }


        }
    }
}
;