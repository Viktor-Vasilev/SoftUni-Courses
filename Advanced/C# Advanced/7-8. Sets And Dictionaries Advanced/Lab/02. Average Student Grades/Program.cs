using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1._Lab_02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];

                decimal grade = decimal.Parse(input[1]);

                if (!grades.ContainsKey(name))
                {
                    grades.Add(name, new List<decimal>());
                }

                grades[name].Add(grade);
            }

            foreach (var grade in grades)
            {
                StringBuilder allGrades = new StringBuilder();

                for (int i = 0; i < grade.Value.Count; i++)
                {
                    allGrades.Append($"{grade.Value[i]:f2} ");
                }

                Console.WriteLine($"{grade.Key} -> {allGrades.ToString().Trim()} (avg: {grade.Value.Average():f2})");
            }

            // печатането може и така:

            //foreach (var student in students)
            //{
            //    StringBuilder sb = new StringBuilder();

            //    foreach (var grade in student.Value)
            //    {
            //        sb.Append($"{grade:f2} ");
            //    }
            //    Console.WriteLine($"{student.Key} -> {sb}(avg: {student.Value.Average():f2})");

            //}

        }
    }
}
