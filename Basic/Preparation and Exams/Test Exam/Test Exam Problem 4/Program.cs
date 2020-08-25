using System;

namespace Test_Exam_Problem_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int passengers = int.Parse(Console.ReadLine());

            int numStops = int.Parse(Console.ReadLine());


            for (int stop = 1; stop <= numStops; stop++)
            {
                int slizashti = int.Parse(Console.ReadLine());
                int kachvashti = int.Parse(Console.ReadLine());

                passengers = (passengers - slizashti + kachvashti);

                if (stop % 2 == 0)
                {
                    passengers = passengers - 2;
                }
                else
                {
                    passengers = passengers + 2;
                }
            }

            Console.WriteLine($"The final number of passengers is : {passengers}");





        }
    }
}
