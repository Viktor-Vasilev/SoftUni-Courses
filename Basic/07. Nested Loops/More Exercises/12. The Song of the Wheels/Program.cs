using System;

namespace _12._The_song_of_the_wheels
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());

            int counter = 0;

            string password = "";

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            if (m == ((a * b) + (c * d)))
                            {
                                if (a < b && c > d)
                                {
                                    Console.Write($"{a}{b}{c}{d} ");
                                    
                                    counter++;

                                    if (counter == 4)
                                    {
                                        password = $"{a}{b}{c}{d}";                  
                                    }
                                    
                                }
                            }
                        }
                    }
                }
            }

            if (counter >= 4)
            {
                Console.WriteLine();
                Console.WriteLine($"Password: {password}");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"No!");
            }
            
        }
    }
}
