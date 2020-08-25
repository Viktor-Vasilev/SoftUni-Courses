using System;

namespace _06._Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            for (int numFloors = floors; numFloors >= 1; numFloors--)
            {
                for (int numRooms = 0; numRooms < rooms; numRooms++)
                {
                    if (numFloors == floors)
                    {
                        Console.Write($"L{numFloors}{numRooms} ");
                    }
                    else if (numFloors % 2 == 0)
                    {
                        Console.Write($"O{numFloors}{numRooms} ");
                    }
                    else
                    {
                        Console.Write($"A{numFloors}{numRooms} ");
                    }
                }
                Console.WriteLine();

            }
        }
    }
}
