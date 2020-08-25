using System;

namespace _10._Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine()); 
            int lenght = int.Parse(Console.ReadLine()); 
            int height = int.Parse(Console.ReadLine());

            int diff = 0;

            int takenPlace = 0;

            int freeSpace = width * lenght * height;

            string command = Console.ReadLine();

            while (command != "Done")
            {
                int boxSpace = int.Parse(command);

                takenPlace += boxSpace;

                diff = Math.Abs(freeSpace - takenPlace);

                if (takenPlace > freeSpace)
                {                  
                    Console.WriteLine($"No more free space! You need {diff} Cubic meters more.");
                    break;
                }

                command = Console.ReadLine();

            }

            if (command == "Done")
            {
                Console.WriteLine($"{diff} Cubic meters left.");
            }
        }
    }
}
