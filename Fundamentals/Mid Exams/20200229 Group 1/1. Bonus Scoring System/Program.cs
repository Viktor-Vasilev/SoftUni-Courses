using System;

namespace _20200229_Group_1__Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int lectures = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());

            double recordBonus = 0;
            int recordAtendance = 0;

            for (int i = 0; i < students; i++)
            {
                int attendance = int.Parse(Console.ReadLine());

                double totalBonus = ((attendance * 1.0 / lectures) * (5 + bonus));

                if (recordBonus < totalBonus)
                {
                    recordBonus = totalBonus;
                    recordAtendance = attendance;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(recordBonus)}.");
            Console.WriteLine($"The student has attended {recordAtendance} lectures.");
        }



    }
    
}
