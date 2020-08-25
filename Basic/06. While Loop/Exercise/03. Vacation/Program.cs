using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double readyMoney = double.Parse(Console.ReadLine());

            int counterSpendDays = 0;

            int days = 0;

            while (counterSpendDays < 5 && readyMoney < neededMoney )
            {
                string action = Console.ReadLine();
                double sum = double.Parse(Console.ReadLine());

                if (action == "spend")
                {
                    days++;
                    counterSpendDays++;
                    if (readyMoney > sum)
                    {
                        readyMoney -= sum;
                    }
                    else
                    {
                        readyMoney = 0;
                    }
                }

                else if (action == "save")
                {
                    readyMoney += sum;
                    days++;
                    counterSpendDays = 0;
                }
                

            }

                if (counterSpendDays == 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine(days);
                }

                if (readyMoney >= neededMoney)
                {
                    Console.WriteLine($"You saved the money for {days} days.");
                }



        }
    }
}
