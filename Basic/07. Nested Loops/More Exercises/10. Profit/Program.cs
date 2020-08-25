using System;

namespace _10._Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int edinLev = int.Parse(Console.ReadLine()); 
            int dvaLeva = int.Parse(Console.ReadLine()); 
            int petLeva = int.Parse(Console.ReadLine()); 
            int suma = int.Parse(Console.ReadLine());

            for (int num1Lev = 0; num1Lev <= edinLev; num1Lev++)
            {
                for (int num2Leva = 0; num2Leva <= dvaLeva; num2Leva++)
                {
                    for (int num5Leva = 0; num5Leva <= petLeva; num5Leva++)
                    {
                        if ((num1Lev * 1) + (num2Leva * 2) + (num5Leva * 5) == suma)
                        {
                            Console.WriteLine($"{num1Lev} * 1 lv. + {num2Leva} * 2 lv. + {num5Leva} * 5 lv. = {suma} lv.");
                        }
                    }
                }
            }


        }
    }
}
