using System;

namespace _01._Pipes_In_Pool
{
    class Program
    {
        static void Main(string[] args)
        {
            int volumePool = int.Parse(Console.ReadLine());
            int debitPipe1 = int.Parse(Console.ReadLine());
            int debitPipe2 = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double poolState = ((debitPipe1 * hours) + (debitPipe2 * hours)); //колко е пълен басейна
            if (poolState <= volumePool)
            {
                double PrinosPipe1 = debitPipe1 * hours / poolState * 100;
                double PrinosPipe2 = debitPipe2 * hours / poolState * 100;

                Console.WriteLine($"The pool is {poolState / volumePool * 100:F2}% full. Pipe 1: {PrinosPipe1:F2}%. Pipe 2:{PrinosPipe2:F2}%.");

            }
            else if (poolState > volumePool)
            {
                Console.WriteLine($"For {hours} hours the pool overflows with {poolState - volumePool:F2} liters.");
            }

        }
    }
}
