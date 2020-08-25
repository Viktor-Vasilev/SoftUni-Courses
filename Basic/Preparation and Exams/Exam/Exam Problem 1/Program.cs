using System;

namespace Exam_Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoins = int.Parse(Console.ReadLine()); 
            double uans = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine());

            double incomeFromBitcoin = bitcoins * 1168 / 1.95;
            double incomeFromUans = uans * 0.15 * 1.76 / 1.95;
            double total = ((incomeFromBitcoin + incomeFromUans) * (100 - commission)) / 100;

            Console.WriteLine($"{total:F2}");
        }
    }
}
