using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());  
            int lenght = int.Parse(Console.ReadLine());

            int pieces = width * lenght;

            string command = Console.ReadLine();

            while (command != "STOP")
            {
                int piecesTaken = int.Parse(command);
                pieces -= piecesTaken;

                if (pieces <= 0)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(pieces)} pieces more.");
                    break;
                }
                command = Console.ReadLine();
            }
            if (command == "STOP")
            {
                Console.WriteLine($"{pieces} pieces are left.");
            }

        }
    }
}
