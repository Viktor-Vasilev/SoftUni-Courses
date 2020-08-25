using System;
using System.Linq;
using System.Collections.Generic;

namespace _00_MidExam_Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int employe11PerHour = int.Parse(Console.ReadLine());
            int employe12PerHour = int.Parse(Console.ReadLine());
            int employe13PerHour = int.Parse(Console.ReadLine());

            int totalPeople = int.Parse(Console.ReadLine());

            int totalPeoplePerHour = employe11PerHour + employe12PerHour + employe13PerHour;

            int hourCount = 0;

            while (totalPeople > 0)
            {
                hourCount++;

                if (hourCount % 4 == 0)
                {
                    continue;
                }
                totalPeople -= totalPeoplePerHour;
            }
            Console.WriteLine($"Time needed: {hourCount}h.");
        }
    }
}
