using System;

namespace Izpit_20190615_5._1_Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actorsName = Console.ReadLine();
            double pointsSoFar = double.Parse(Console.ReadLine());
            int numOcenitel = int.Parse(Console.ReadLine());

            double pointsToAdd = 0.0;

            for (int i = 1; i <= numOcenitel; i++)
            {
                string nameOcenitel = Console.ReadLine();
                double pointsFromOcenitel = double.Parse(Console.ReadLine());

                pointsToAdd = nameOcenitel.Length * pointsFromOcenitel / 2;
                pointsSoFar += pointsToAdd;

                if (pointsSoFar >= 1250.5)
                {
                    Console.WriteLine($"Congratulations, {actorsName} got a nominee for leading role with {pointsSoFar:F1}!");
                    break;
                }

            }

            double diff = 1250.5 - pointsSoFar;

            if (pointsSoFar < 1250.5)
            {
                Console.WriteLine($"Sorry, {actorsName} you need {diff:F1} more!");
            }

        }
    }
}
