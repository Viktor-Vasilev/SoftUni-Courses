using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Lab_5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(numbers);

            //foreach (var item in queue)
            //{
            //    Console.Write(item);
            //}

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = queue.Peek();

                if (currentNumber % 2 == 0)
                {
                    queue.Dequeue();
                    queue.Enqueue(currentNumber);
                }
                else
                {
                    queue.Dequeue();
                    // i--; - може и без това!
                }

            }

            Console.WriteLine(String.Join(", ", queue));

        }
    }
}
