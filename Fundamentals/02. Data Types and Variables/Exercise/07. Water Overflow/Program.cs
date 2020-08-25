using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = 255;

            int numPours = int.Parse(Console.ReadLine());

            int full = 0;

            for (int currentPour = 1; currentPour <= numPours; currentPour++)
            {
                int litersPerPour = int.Parse(Console.ReadLine());

                if (capacity >= litersPerPour)
                {
                    capacity -= litersPerPour;
                    full += litersPerPour;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                    
            }
            Console.WriteLine(full);

            //int capacity = 255;

            //int n = int.Parse(Console.ReadLine());

            //int counter = 0;

            //while (n > counter)
            //{
            //    int pour = int.Parse(Console.ReadLine());

            //    if (pour <= capacity)
            //    {
            //        capacity -= pour;
            //        counter++;

            //    }
            //    else
            //    {
            //        Console.WriteLine("Insufficient capacity!");
            //        counter++;
            //    }

            //}

            //Console.WriteLine(255 - capacity);

        }
    }
}
