using System;

namespace _04._Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            string presentationName = Console.ReadLine();

            double sumGradesAll = 0;

            int counterForAllGrades = 0;

            while (presentationName != "Finish")
            {
                double sumGradesCurrent = 0;

                for (int i = 1; i <= n; i++)
                {
                    double currentGrade = double.Parse(Console.ReadLine());
                    sumGradesCurrent += currentGrade;
                    sumGradesAll += currentGrade;
                    counterForAllGrades++;
                }
                double currentSredenUspeh = sumGradesCurrent / n;
                Console.WriteLine($"{presentationName} - {currentSredenUspeh:F2}.");

                presentationName = Console.ReadLine();
            }
            if (presentationName == "Finish")
            {
                double sredenUspehAll = sumGradesAll * 1.0 / counterForAllGrades;
                Console.WriteLine($"Student's final assessment is {sredenUspehAll:F2}.");
            }

        }
    }
}
