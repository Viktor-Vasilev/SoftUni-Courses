using System;

namespace _01._Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int row = 1; row <= n; row++)
            {

                for (int column = 1; column <= row; column++)
                {
                    counter++;
                    Console.Write(counter + " ");
                    if (counter == n)
                    {
                        break;
                    }

                }
                Console.WriteLine();

                if (counter == n)
                { 
                    break;
                }
            }
        }
    }
}
