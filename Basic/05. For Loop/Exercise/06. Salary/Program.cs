using System;

namespace _06._Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int openTabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 1; i <= openTabs; i++)
            {
                string tabName = Console.ReadLine();

                if (tabName == "Facebook")
                {
                    salary -= 150;
                }
                else if (tabName == "Instagram")
                {
                    salary -= 100;
                }
                else if (tabName == "Reddit")
                {
                    salary -= 50;
                }

                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }

            if (salary > 0)
            {
                Console.WriteLine(salary);
            }
        }
    }
}
