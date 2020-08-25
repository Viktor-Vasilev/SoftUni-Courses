using System;

namespace Izpit_20190706_5._2_PC_Game_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int Hearthstone = 0;
            int Fornite = 0;
            int Overwatch = 0;
            int Others = 0;

            for (int i = 1; i <= n; i++)
            {
                string gameName = Console.ReadLine();

                if (gameName == "Hearthstone")
                {
                    Hearthstone++;
                }
                else if (gameName == "Fornite")
                {
                    Fornite++;
                }
                else if (gameName == "Overwatch")
                {
                    Overwatch++;
                }
                else
                {
                    Others++;
                }
            }

            double percentHearthstone = Hearthstone * 1.0 / n * 100;
            double percentFornite= Fornite * 1.0 / n * 100;
            double percentOverwatch = Overwatch * 1.0 / n * 100;
            double percentOthers = Others * 1.0 / n * 100;

            Console.WriteLine($"Hearthstone - {percentHearthstone:F2}%");
            Console.WriteLine($"Fornite - {percentFornite:F2}%");
            Console.WriteLine($"Overwatch - {percentOverwatch:F2}%");
            Console.WriteLine($"Others - {percentOthers:F2}%");


        }
    }
}
