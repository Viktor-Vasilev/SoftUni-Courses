using System;

namespace Izpit_20190615_4._1_Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            int incomeTotal = 0;

            while (command != "Movie time!")
            {
                int currentPeople = int.Parse(command);

                if (capacity < currentPeople)
                {
                    Console.WriteLine("The cinema is full.");
                    Console.WriteLine($"Cinema income - {incomeTotal} lv.");
                    break;
                }

                if (capacity >= currentPeople)
                {
                    if (currentPeople % 3 == 0)
                    {
                        incomeTotal += ((currentPeople * 5) - 5); 
                    }
                    if (currentPeople % 3 != 0)
                    {
                        incomeTotal += currentPeople * 5;
                    }
                    capacity -= currentPeople;
                }
                
                command = Console.ReadLine();
            }
            if (command == "Movie time!")
            {
                Console.WriteLine($"There are {capacity} seats left in the cinema.");
                Console.WriteLine($"Cinema income - {incomeTotal} lv.");
            }

        }
    }
}
