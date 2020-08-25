using System;

namespace Exam_Problem_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());           

            int counterForDayWins = 0;
            int counterForDayLossess = 0;

            int counterWonDays = 0;
            int counterLostDays = 0;

            double wonMoneyAll = 0;

            for (int day = 1; day <= days; day++)
            {
                string gameName = Console.ReadLine();

                double wonMoneyCurrentDay = 0;

                counterForDayWins = 0;
                counterForDayLossess = 0;
             
                while (gameName != "Finish")
                {
                    string result = Console.ReadLine();

                    if (result == "win")
                    {
                        counterForDayWins++;
                        wonMoneyCurrentDay += 20;
                    }
                    else
                    {
                        counterForDayLossess++;
                    }

                    gameName = Console.ReadLine();
                }

                if (counterForDayWins > counterForDayLossess)
                {
                    counterWonDays++;
                    wonMoneyCurrentDay *= 1.10;
                }
                else
                {                   
                    counterLostDays++;
                }

                wonMoneyAll += wonMoneyCurrentDay;
            }

            if (counterWonDays > counterLostDays)
            {
                wonMoneyAll *= 1.20;
                Console.WriteLine($"You won the tournament! Total raised money: {wonMoneyAll:F2}");
            }
            if (counterLostDays > counterWonDays)
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {wonMoneyAll:F2}");
            }
            
        }
    }
}
