using System;

namespace _02._Report_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int goal = int.Parse(Console.ReadLine());

            int counter = 1;

            int addedSum = 0;

            string command = Console.ReadLine();

            int cash = 0;
            int cashTrans = 0;

            int card = 0;
            int cardTrans = 0;

            while (command != "End")
            {
                int currentSum = int.Parse(command);
                
                if (counter % 2 != 0 && currentSum <= 100)
                {
                    addedSum += currentSum;
                    cash += currentSum;
                    cashTrans++;
                    Console.WriteLine("Product sold!");
                }
                if (counter % 2 != 0 && currentSum > 100)
                {
                    Console.WriteLine("Error in transaction!");
                }
                if (counter % 2 == 0 && currentSum >= 10)
                {
                    addedSum += currentSum;
                    card += currentSum;
                    cardTrans++;
                    Console.WriteLine("Product sold!");
                }
                if (counter % 2 == 0 && currentSum < 10)
                {
                    Console.WriteLine("Error in transaction!");
                }

                counter++;

                double averCash = cash * 1.0 / cashTrans;
                double averCard = card * 1.0 / cardTrans;


                if (addedSum >= goal)
                {
                    Console.WriteLine($"Average CS: {averCash:F2}");
                    Console.WriteLine($"Average CC: {averCard:F2}");
                    break;
                }

                command = Console.ReadLine();

            }

            if (command == "End")
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }

        }
    }
}
