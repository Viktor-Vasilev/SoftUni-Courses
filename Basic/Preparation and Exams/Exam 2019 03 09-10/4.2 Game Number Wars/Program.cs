using System;

namespace Izpit_20190420_4._2_Game_Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string player1 = Console.ReadLine(); 
            string player2 = Console.ReadLine();

            int pointsPlayer1 = 0;
            int pointsPlayer2 = 0;

            string command = Console.ReadLine();

            while (command != "End of game")
            {
                int player1Card = int.Parse(command);
                int player2Card = int.Parse(Console.ReadLine());

                if (player1Card > player2Card)
                {
                    pointsPlayer1 += player1Card - player2Card;
                }
                if (player2Card > player1Card)
                {
                    pointsPlayer2 += player2Card - player1Card;
                }
                if (player1Card == player2Card)
                {
                   
                    int player1CardAdd = int.Parse(Console.ReadLine());
                    int player2CardAdd = int.Parse(Console.ReadLine());
                    Console.WriteLine("Number wars!");
                    if (player1CardAdd > player2CardAdd)
                    {
                        Console.WriteLine($"{player1} is winner with {pointsPlayer1} points");
                        break;
                    }
                    if (player2CardAdd > player1CardAdd)
                    {
                        Console.WriteLine($"{player2} is winner with {pointsPlayer2} points");
                        break;
                    }
                }

                command = Console.ReadLine();

            }
            if (command == "End of game")
            {
                Console.WriteLine($"{player1} has {pointsPlayer1} points");
                Console.WriteLine($"{player2} has {pointsPlayer2} points");
            }


        }
    }
}
