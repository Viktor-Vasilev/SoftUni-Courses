using System;

namespace _20191210_Retake_Disneyland_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());

            double savedMoney = 0;

            for (int i = 1; i <= months; i++)
            {
                if (i % 2 != 0 && i != 1)
                {
                    savedMoney *= 0.84;
                }

                if(i % 4 == 0)
                {
                    savedMoney *= 1.25;
                }

                savedMoney += neededMoney * 0.25;
            }

            if (savedMoney >= neededMoney)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {savedMoney - neededMoney:f2}lv. for souvenirs.");
            }
            else
            {
                Console.WriteLine($"Sorry. You need {neededMoney - savedMoney:f2}lv. more.");
            }


        }
    }
}
