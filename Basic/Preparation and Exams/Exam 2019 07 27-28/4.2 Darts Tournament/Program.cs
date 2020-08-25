using System;

namespace Izpit_20190727_4._2_Darts_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {

            int points = int.Parse(Console.ReadLine());

            int numThrows = 0;

            string command = Console.ReadLine();

            while (command != "bullseye")
            {
                int currentHitPoints = int.Parse(Console.ReadLine());

                

                if (command == "double ring")
                {
                    currentHitPoints *= 2;
                }
                if (command == "triple ring")
                {
                    currentHitPoints *= 3;
                }

                numThrows++;

                points -= currentHitPoints; 

                if (points < 0)
                {
                    Console.WriteLine($"Sorry, you lost. Score difference: {Math.Abs (points)}.");
                    break;
                }
                if (points == 0)
                {
                    Console.WriteLine($"Congratulations! You won the game in {numThrows} moves!");
                    break;
                }

                command = Console.ReadLine();
            }

            if (command == "bullseye")
            {
                numThrows++;
                Console.WriteLine($"Congratulations! You won the game with a bullseye in {numThrows} moves!");
            }

        }
    }
}
