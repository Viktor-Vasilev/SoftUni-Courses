using System;

namespace _20190806_Retake_Black_Flag
{
    class Program
    {
        static void Main(string[] args)
        {
            //long days = long.Parse(Console.ReadLine());
            //decimal dailyPlunder = decimal.Parse(Console.ReadLine());
            //decimal goalPlunder = decimal.Parse(Console.ReadLine());

            //decimal additionalPlunder = 0;
            //decimal totalPlunder = 0;

            //for (int i = 1; i <= days; i++)
            //{
            //    if (i % 3 == 0)
            //    {
            //        additionalPlunder = dailyPlunder * 1.5m;
            //        totalPlunder += additionalPlunder;
            //    }
            //    else
            //    {
            //        totalPlunder += dailyPlunder;
            //    }

            //    if(i % 5 == 0)
            //    {
            //        totalPlunder *= 0.7m;
            //    }



            //}

            //if (totalPlunder >= goalPlunder)
            //{
            //    Console.WriteLine($"Ahoy! {totalPlunder} plunder gained.");
            //    return;
            //}
            //else 
            //{
            //    decimal percentage = (totalPlunder / goalPlunder) * 100;
            //    Console.WriteLine($"Collected only {percentage:f2}% of the plunder.");
            //}


            int daysofPlunder = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double goalPlunder = double.Parse(Console.ReadLine());

            double totalPlunder = 0;



            for (int i = 1; i <= daysofPlunder; i++)
            {
                totalPlunder += dailyPlunder;

                if (i % 3 == 0)
                {
                    totalPlunder += dailyPlunder * 0.5;
                }
                if (i % 5 == 0)
                {

                    totalPlunder = totalPlunder - (totalPlunder * 0.3);
                }

            }

            if (totalPlunder >= goalPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                totalPlunder = totalPlunder * 100 / goalPlunder;
                Console.WriteLine($"Collected only {totalPlunder:f2}% of the plunder.");
            }



        }
    }
}
