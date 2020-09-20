using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Exer_7._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumps = int.Parse(Console.ReadLine());

            Queue<string> circle = new Queue<string>();

            for (int i = 0; i < pumps; i++)
            {
                string input = Console.ReadLine();

                input += $" {i}"; // запазваме за всяка станция от която тръгваме

                circle.Enqueue(input);
            }

            int totalFuel = 0;

            for (int i = 0; i < pumps; i++)
            {
                string currentInfo = circle.Dequeue();

                int[] info = currentInfo.Split().Select(int.Parse).ToArray();

                int fuel = info[0];
                int distance = info[1];

                totalFuel += fuel;

                if (totalFuel >= distance)
                {
                    totalFuel -= distance;
                }
                else
                {
                    totalFuel = 0;
                    i = -1;
                }

                circle.Enqueue(currentInfo);

            }

            string[] firstElement = circle.Dequeue().Split().ToArray();

            Console.WriteLine(firstElement[2]);

            //int n = int.Parse(Console.ReadLine());
            //Queue<int[]> queue = new Queue<int[]>();

            //for (int i = 0; i < n; i++)
            //{
            //    int[] parameters = Console.ReadLine()
            //                              .Split()
            //                              .Select(int.Parse)
            //                              .ToArray();
            //    queue.Enqueue(parameters);
            //}

            //int index = 0;
            //while (true)
            //{
            //    int fuel = 0;
            //    foreach (int[] petrolPump in queue)
            //    {
            //        fuel += petrolPump[0] - petrolPump[1];
            //        if (fuel < 0)
            //        {
            //            index++;
            //            int[] currentPump = queue.Dequeue();
            //            queue.Enqueue(currentPump);
            //            break;
            //        }
            //    }

            //    if (fuel >= 0)
            //    {
            //        break;
            //    }
            //}

            //Console.WriteLine(index);
        }
    }
}
