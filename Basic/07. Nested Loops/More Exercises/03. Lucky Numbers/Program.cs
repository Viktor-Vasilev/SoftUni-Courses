using System;

namespace _03._Lucky_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int pos1 = 1; pos1 <= 9; pos1++)
            {
                for (int pos2 = 1; pos2 <= 9; pos2++)
                {
                    for (int pos3 = 1; pos3 <= 9; pos3++)
                    {
                        for (int pos4 = 1; pos4 <= 9; pos4++)
                        {
                            if ((pos1 + pos2) == (pos3 + pos4) && (n % (pos1 + pos2) == 0))
                            {
                                Console.Write($"{pos1}{pos2}{pos3}{pos4} ");
                            }

                        }
                    }
                }
            }
        }
    }
}
