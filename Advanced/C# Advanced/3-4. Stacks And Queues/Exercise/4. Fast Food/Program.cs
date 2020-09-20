using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Exer_4._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int availableFood = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int maxOrder = orders.Max();

            Queue<int> queue = new Queue<int>(orders);
            // няма да проверявам за отрицателни поръчки и т.н., само ако се наложи!

            // Console.WriteLine(orders.Sum());

            if (orders.Sum() <= availableFood)
            {
                Console.WriteLine(maxOrder);
                Console.WriteLine("Orders complete");
                return;
            }

            

            while (true)
            {
                int currentOrder = queue.Peek();

                if (currentOrder <= availableFood)
                {
                    availableFood -= currentOrder;

                    queue.Dequeue();
                }
                else
                {
                    Console.WriteLine(maxOrder);
                    Console.WriteLine($"Orders left: " + String.Join(" ", queue));
                    return;
                }


            }

            // по елегантно решение!

            //int food = int.Parse(Console.ReadLine());
            //int[] orders = Console.ReadLine()
            //                      .Split(" ")
            //                      .Select(int.Parse)
            //                      .ToArray();
            //Queue<int> queue = new Queue<int>(orders);
            //Console.WriteLine(queue.Max());

            //for (int i = 0; i < orders.Length; i++)
            //{
            //    if (queue.Count != 0)
            //    {
            //        if (queue.Peek() > food)
            //        {
            //            break;
            //        }

            //        food -= queue.Dequeue();
            //    }
            //}

            //Console.WriteLine(queue.Count == 0 ? "Orders complete" : $"Orders left: {String.Join(" ", queue)}");

        }
    }
}
