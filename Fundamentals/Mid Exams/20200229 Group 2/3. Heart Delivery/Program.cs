using System;
using System.Linq;
using System.Collections.Generic;

namespace _20200229_Group_2__3._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine().Split('@').Select(int.Parse).ToList();

            int houseCount = 0;

            int lastPositionIndex = 0;

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "Love!")
                {
                    break;
                }
                else if (command[0] == "Jump")
                {
                    int length = int.Parse(command[1]);

                    lastPositionIndex += length;

                    if (lastPositionIndex >= houses.Count) // трябва да е с равно задължително!!
                    {
                        lastPositionIndex = 0;
                    }

                    if (houses[lastPositionIndex] == 0)
                    {
                        Console.WriteLine($"Place {lastPositionIndex} already had Valentine's day.");
                        
                    }
                    else
                    {
                        houses[lastPositionIndex] -= 2;
                        if (houses[lastPositionIndex] == 0)
                        {
                            Console.WriteLine($"Place {lastPositionIndex} has Valentine's day.");
                            houseCount++;
                        }
                    }

                }

            }
            Console.WriteLine($"Cupid's last position was {lastPositionIndex}.");

            if (houses.Sum() == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {houses.Count - houseCount} places.");
            }

        }

    }
}



