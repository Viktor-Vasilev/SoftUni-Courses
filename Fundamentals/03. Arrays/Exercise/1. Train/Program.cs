using System;

namespace _1._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            int[] wagonsPeople = new int[wagons];
            int sum = 0;

            for (int i = 0; i < wagons; i++)
            {
                int people = int.Parse(Console.ReadLine());
                wagonsPeople[i] = people;
                sum += people;
            }

            Console.WriteLine(String.Join(" ", wagonsPeople));
            Console.WriteLine(sum);




        }
    }
}
