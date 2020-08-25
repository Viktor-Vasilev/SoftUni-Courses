using System;

namespace _08._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentsName = Console.ReadLine();

            int counter = 1;

            double sumGrades = 0;

            while (counter <= 12)
            {
                double currentGrade = double.Parse(Console.ReadLine());

                if (currentGrade >= 4.00)
                {
                    sumGrades += currentGrade;
                    counter++;
                }

            }

            double averageGrade = sumGrades / 12;

            Console.WriteLine($"{studentsName} graduated. Average grade: {averageGrade:F2}");


        }
    }
}
