using System;
using System.Linq;
using System.Collections.Generic;

namespace _20200229_Group_1__2._MU_Online
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;

            List<string> rooms = Console.ReadLine().Split('|').ToList();


            for (int i = 0; i < rooms.Count; i++)
            {
                string command = rooms[i];
                string[] splitted = command.Split();

                if (splitted[0] == "potion")
                {
                    int tempHealth = health;

                    tempHealth += int.Parse(splitted[1]);

                    if (tempHealth <= 100)
                    {
                        health = tempHealth;
                        Console.WriteLine($"You healed for {splitted[1]} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else if (tempHealth > 100)
                    {                       
                        Console.WriteLine($"You healed for {100 - health} hp.");
                        health = 100;
                        Console.WriteLine($"Current health: {health} hp.");                     
                    }
                }
                else if (splitted[0] == "chest")
                {
                    int foundBitcoins = int.Parse(splitted[1]);
                    bitcoins += foundBitcoins;
                    Console.WriteLine($"You found {foundBitcoins} bitcoins.");
                }
                else
                {
                    int attack = int.Parse(splitted[1]);

                    health -= attack;

                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {splitted[0]}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {splitted[0]}.");
                    }
                }

            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");

        }
    }
}
