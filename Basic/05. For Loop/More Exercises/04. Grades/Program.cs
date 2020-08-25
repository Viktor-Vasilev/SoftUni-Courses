using System;

namespace _04._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numStudents = int.Parse(Console.ReadLine());

            int group1 = 0;
            int group2 = 0;
            int group3 = 0;
            int group4 = 0;

            double sumGrades = 0;

            for (int i = 1; i <= numStudents; i++)
            {
                double mark = double.Parse(Console.ReadLine());

                if (mark >= 5.00)
                {
                    group1++;
                    sumGrades += mark;
                }
                else if (mark >= 4.00 && mark <= 4.99)
                {
                    group2++;
                    sumGrades += mark;
                }
                else if (mark >= 3.00 && mark <= 3.99)
                {
                    group3++;
                    sumGrades += mark;
                }
                else
                {
                    group4++;
                    sumGrades += mark;
                }
            }

            double percentGroup1 = group1 * 1.0 / numStudents * 100;
            double percentGroup2 = group2 * 1.0 / numStudents * 100;
            double percentGroup3 = group3 * 1.0 / numStudents * 100;
            double percentGroup4 = group4 * 1.0 / numStudents * 100;
            double averageMark = sumGrades / numStudents;

            Console.WriteLine($"Top students: {percentGroup1:F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {percentGroup2:F2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {percentGroup3:F2}%");
            Console.WriteLine($"Fail: {percentGroup4:F2}%");
            Console.WriteLine($"Average: {averageMark:F2}");
        }
    }
}
