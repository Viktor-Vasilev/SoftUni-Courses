using System;

namespace Test_Exam_Problem_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int singer = int.Parse(Console.ReadLine());

            int guests = 0;

            int moneyFor1Guest = 0;

            int moneyAll = 0;

            string command = Console.ReadLine();

            while (command != "The restaurant is full")
            {
                int numGuests = int.Parse(command);

                if (numGuests < 5)
                {
                    moneyFor1Guest = 100;
                }
                else
                {
                    moneyFor1Guest = 70;
                }

                guests += numGuests;

                moneyAll += numGuests * moneyFor1Guest;

                command = Console.ReadLine();

            }

            if (command == "The restaurant is full")
            {
                if (moneyAll >= singer)
                {
                    Console.WriteLine($"You have {guests} guests and {moneyAll - singer} leva left.");
                }
                else
                {
                    Console.WriteLine($"You have {guests} guests and {moneyAll} leva income, but no singer.");
                }

            }






        }
    }
}
