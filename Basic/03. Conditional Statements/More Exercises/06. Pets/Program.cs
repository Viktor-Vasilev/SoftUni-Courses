using System;

namespace _06._Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int absentDays = int.Parse(Console.ReadLine());
            int leftFoodinKGs = int.Parse(Console.ReadLine());
            double foodDogForDay = double.Parse(Console.ReadLine());
            double foodCatForDay = double.Parse(Console.ReadLine());
            double foodTurtleForDay = double.Parse(Console.ReadLine());

            double neededFood = ((absentDays * foodDogForDay) + (absentDays * foodCatForDay) + (absentDays * foodTurtleForDay / 1000));
            // Console.WriteLine(neededFood);
            if (leftFoodinKGs >= neededFood)
            {
                double razlika = Math.Floor(leftFoodinKGs - neededFood);
                Console.WriteLine($"{razlika} kilos of food left.");
            }
            else if (leftFoodinKGs < neededFood)
            {
                double razlika = Math.Ceiling(neededFood - leftFoodinKGs);
                Console.WriteLine($"{razlika} more kilos of food are needed.");

            }

        }
    }
}
