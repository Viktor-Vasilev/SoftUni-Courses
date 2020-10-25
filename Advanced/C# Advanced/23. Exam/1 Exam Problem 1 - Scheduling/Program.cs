using System;
using System.Collections.Generic;
using System.Linq;

namespace _1_Exam_Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] taskValue = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] threadValue = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int taskToBeKilled = int.Parse(Console.ReadLine());

            Queue<int> thread = new Queue<int>(threadValue);
            Stack<int> task = new Stack<int>(taskValue);

            // Console.WriteLine(string.Join(" ", thread));
            //Console.WriteLine(string.Join(" ", task));
            int killer = 0;

            while (true)
            {
                int currentThread = thread.Peek();
                int currentTask = task.Peek();

                if (currentTask == taskToBeKilled)
                {
                    killer = currentThread;
                    break;
                }

                else if (currentThread >= currentTask)
                {
                    thread.Dequeue();
                    task.Pop();
                }
                else if (currentThread < currentTask)
                {
                    thread.Dequeue();
                }

            }

            Console.WriteLine($"Thread with value {killer} killed task {taskToBeKilled}");
            if (thread.Any())
            {
                Console.WriteLine(string.Join(" ", thread));
            }

        }
    }
}
