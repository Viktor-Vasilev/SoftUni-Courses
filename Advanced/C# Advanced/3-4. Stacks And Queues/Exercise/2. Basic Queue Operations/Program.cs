using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Exer_2._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int numbersToEnqueue = input[0];
            int numbersToDequeue = input[1];
            int numberToFind = input[2];

            
            Queue<int> queue = new Queue<int>(numbers);

            // Може да проверим за идиотщини в условието, дали не ни подават мизерии!

            //Queue<int> queue = new Queue<int>();

            //for (int i = 0; i < numbersToDequeue; i++)
            //{
            //    if (numbers.Length - 1 < i)
            //    {
            //        break;
            //    }
            //    queue.Enqueu(numbers[i]);
            //}

            for (int i = 0; i < numbersToDequeue; i++)
            {
                if (queue.Count == 0)
                {
                    break;
                }

                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (queue.Contains(numberToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine($"{queue.Min()}");
            }


        }
    }
}
