using System;

namespace _01._Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            int bottles = int.Parse(Console.ReadLine());

            int detergent = bottles * 750;

            int numDishes = 0;
            int numPots = 0;
            int counter = 1;

            string command = Console.ReadLine();

            while (command != "End")
            {
                int num = int.Parse(command);

                if (counter % 3 == 0)
                {
                    numPots += num;
                    detergent -= (num * 15);
                }

                if (counter % 3 != 0)
                {
                    numDishes += num;
                    detergent -= (num * 5);     
                }

                counter++;

                if (detergent < 0)
                {
                    Console.WriteLine($"Not enough detergent, {Math.Abs(detergent)} ml. more necessary!");
                    break;
                }

                command = Console.ReadLine();
            }
            
            if (command == "End")
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{numDishes} dishes and {numPots} pots were washed.");
                Console.WriteLine($"Leftover detergent {detergent} ml.");

            }

        }
    }
}
