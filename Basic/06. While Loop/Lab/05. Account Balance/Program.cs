using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            int numVnoski = int.Parse(Console.ReadLine());

            int counter = 1;

            double balance = 0.0;


            while (numVnoski >= counter)
            {
                double vnoska = double.Parse(Console.ReadLine());

                

                if (vnoska <= 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                balance += vnoska;

                Console.WriteLine($"Increase: {vnoska:F2}");
                counter++;
            }

            Console.WriteLine($"Total: {balance:F2}");




        }
    }
}
