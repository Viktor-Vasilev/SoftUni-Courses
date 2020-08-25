using System;

namespace _09._Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentsName = Console.ReadLine();

            int counterGrades = 1;

            int fails = 0;

            double sumGrades = 0;

            while (counterGrades <= 12)
            {
                double currentGrade = double.Parse(Console.ReadLine());
                if (currentGrade < 4.00)
                {
                    fails++;
                }
                else if (currentGrade >= 4.00)
                {
                    sumGrades += currentGrade;
                    counterGrades++;
                }

                if (fails == 2)
                {
                    Console.WriteLine($"{studentsName} has been excluded at {counterGrades} grade");
                    break;
                }
            }

            double averageGrade = sumGrades / 12;

            if (fails < 2)
            {
                Console.WriteLine($"{studentsName} graduated. Average grade: {averageGrade:F2}");
            }


        }
    }
}
