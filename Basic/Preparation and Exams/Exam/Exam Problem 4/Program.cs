using System;

namespace Exam_Problem_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int numGroups = int.Parse(Console.ReadLine());

            int counterAllPeople = 0;

            int counterMusala = 0;
            int counterMonblan = 0;
            int counterKilimandjaro = 0;
            int counterK2 = 0;
            int counterEverest = 0;

            for (int group = 1; group <= numGroups; group++)
            {
                int numPeople = int.Parse(Console.ReadLine());

                counterAllPeople += numPeople;

                if (numPeople <= 5)
                {
                    counterMusala += numPeople;
                }
                else if (numPeople > 5 && numPeople <= 12)
                {
                    counterMonblan += numPeople;
                }
                else if (numPeople > 12 && numPeople <= 25)
                {
                    counterKilimandjaro += numPeople;
                }
                else if (numPeople > 25 && numPeople <= 40)
                {
                    counterK2 += numPeople;
                }
                else
                {
                    counterEverest += numPeople;
                }

            }

            double percentMusala = counterMusala * 1.0 / counterAllPeople * 100;
            double percentMonblan = counterMonblan * 1.0 / counterAllPeople * 100;
            double percentKilimandjaro = counterKilimandjaro * 1.0 / counterAllPeople * 100;
            double percentK2 = counterK2 * 1.0 / counterAllPeople * 100;
            double percentEverest = counterEverest * 1.0 / counterAllPeople * 100;

            Console.WriteLine($"{percentMusala:F2}%");
            Console.WriteLine($"{percentMonblan:F2}%");
            Console.WriteLine($"{percentKilimandjaro:F2}%");
            Console.WriteLine($"{percentK2:F2}%");
            Console.WriteLine($"{percentEverest:F2}%");
           
        }
    }
}
