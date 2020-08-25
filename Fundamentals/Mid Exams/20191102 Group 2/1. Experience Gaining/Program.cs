using System;

namespace _20191102_Group_2_Experience_Gaining
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExp = double.Parse(Console.ReadLine());
            int playedBattles = int.Parse(Console.ReadLine());
            

            double gainedExp = 0;
            int battleCount = 0;

           while (playedBattles > 0)
            {
                battleCount++;

                double expPerBattle = double.Parse(Console.ReadLine());

                if (battleCount % 3 == 0)
                {
                    gainedExp += expPerBattle * 1.15;
                }
                else if (battleCount % 5 == 0)
                {
                    gainedExp += expPerBattle * 0.9;
                }
                else
                {
                    gainedExp += expPerBattle;
                }

                playedBattles--;

                if(gainedExp >= neededExp)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {battleCount} battles.");
                    return;
                }

            }

            Console.WriteLine($"Player was not able to collect the needed experience, {neededExp - gainedExp:f2} more needed.");

        }
    }
}
