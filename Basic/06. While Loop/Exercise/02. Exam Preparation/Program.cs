using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPoorGrades = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            string lastProblemName = "";

            int sumGrades = 0;

            int numGrades = 0;

            int countPoorGrades = 0;

            while (command != "Enough")
            {
                int grade = int.Parse(Console.ReadLine());
                lastProblemName = command;
                sumGrades += grade;
                numGrades++;

                if (grade <= 4)
                {
                    countPoorGrades++;
                }

                if (countPoorGrades == numPoorGrades)
                {
                    Console.WriteLine($"You need a break, {numPoorGrades} poor grades.");
                    break;
                }

                command = Console.ReadLine();

            }

            double average = sumGrades * 1.0 / numGrades;

            if (command == "Enough")
            {
                Console.WriteLine($"Average score: {average:F2}");
                Console.WriteLine($"Number of problems: {numGrades}");
                Console.WriteLine($"Last problem: {lastProblemName}");
            }


        }
    }
}
