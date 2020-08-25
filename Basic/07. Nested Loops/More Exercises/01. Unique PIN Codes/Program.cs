using System;

namespace _01.Unique_PIN_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            for (int pos1 = 1; pos1 <= num1; pos1++)
            {
                for (int pos2 = 1; pos2 <= num2; pos2++)
                {
                    for (int pos3 = 1; pos3 <= num3; pos3++)
                    {
                        if (pos1 % 2 == 0 && pos3 % 2 == 0)
                        {
                            if (pos2 == 2 || pos2 == 3 || pos2 == 5 || pos2 == 7)
                            {
                                Console.WriteLine($"{pos1} {pos2} {pos3}");
                            }
                        }
                    }
                }
            }
        }
    }
}
                