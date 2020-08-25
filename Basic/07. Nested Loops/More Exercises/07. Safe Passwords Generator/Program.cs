using System;

namespace _07._Safe_Passwords_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int maxPasswords = int.Parse(Console.ReadLine());

            int nul1 = 35;
            int nul2 = 64;

            for (int i = 1; i <= num1; i++)
            {
                for (int j = 1; j <= num2; j++)
                {
                    if (nul1 > 55)
                    {
                        nul1 = 35;
                    }

                    if (nul2 > 96)
                    {
                        nul2 = 64;
                    }

                    if (maxPasswords == 0)
                    {
                        return;
                    }

                    Console.Write($"{(char)nul1}{(char)nul2}{i}{j}{(char)nul2}{(char)nul1}|");

                    nul1++;
                    nul2++;

                    maxPasswords--;

                }
            }

        }
    }
}
