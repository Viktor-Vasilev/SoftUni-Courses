using System;

namespace _20200407_Retake_Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingEnergy = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            int counter = 0;

            while (command != "End of battle")
            {
                int distance = int.Parse(command);

                if (startingEnergy >= distance)
                {
                    startingEnergy -= distance;
                    counter++;
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {counter} won battles and {startingEnergy} energy");
                    return;
                }

                if (counter % 3 == 0)
                {
                    startingEnergy += counter;
                }

                command = Console.ReadLine();
            }


            Console.WriteLine($"Won battles: {counter}. Energy left: {startingEnergy}");

        }
    }
}
