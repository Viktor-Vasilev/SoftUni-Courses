using System;

namespace Izpit_20190420_4._1_Easter_Eggs_Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            int numEggsPlayer1 = int.Parse(Console.ReadLine()); 
            int numEggsPlayer2 = int.Parse(Console.ReadLine());

            string command = "";

            while (command != "End of battle")
            {
                command = Console.ReadLine();

                if (command == "one")
                {
                    numEggsPlayer2--;
                    
                    if (numEggsPlayer2 == 0)
                    {
                        Console.WriteLine($"Player two is out of eggs. Player one has {numEggsPlayer1} eggs left.");
                        break;
                    }
                }
                if (command == "two")
                {
                    numEggsPlayer1--;
                    
                    if (numEggsPlayer1 == 0)
                    {
                        Console.WriteLine($"Player one is out of eggs. Player two has {numEggsPlayer2} eggs left.");
                        break;
                    }
                }

            }

            if (command == "End of battle")
            {
                Console.WriteLine($"Player one has {numEggsPlayer1} eggs left.");
                Console.WriteLine($"Player two has {numEggsPlayer2} eggs left.");
            }






        }
    }
}
