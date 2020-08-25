using System;

namespace Izpit_20190727_3._2_Luggage_Tax
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());  
            int height = int.Parse(Console.ReadLine());  
            int depth = int.Parse(Console.ReadLine());
            string priority = Console.ReadLine();

            double tax = 0;
            double volume = (lenght * height * depth);

            
            if (volume < 50)
            {
                tax = 0;
            }
            else if (volume >= 50 && volume <= 100)
            {
                if (priority == "true")
                {
                    tax = 0;
                }
                else
                {
                    tax = 25;
                }
            }
            else if (volume > 100 && volume <= 200)
            {
                if (priority == "true")
                {
                    tax = 10;
                }
                else
                {
                    tax = 50;
                }
            }
            else
            {
                if (priority == "true")
                {
                    tax = 20;
                }
                else
                {
                    tax = 100;
                }
            }

            Console.WriteLine($"Luggage tax: {tax:F2}");

        }
    }
}
