using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Exer_1.__Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int numbersToPush = input[0];
            int numbersToPop = input[1];
            int numberToFind = input[2];

            Stack<int> stack = new Stack<int>(numbers);

            // Може да проверим за идиотщини в условието, дали не ни подават мизерии!

            //Stack<int> stack = new Stack<int>();

            //for (int i = 0; i < numbersToPush; i++)
            //{
            //    if (numbers.Length - 1 < i)
            //    {
            //        break;
            //    }
            //    stack.Push(numbers[i]);
            //}




            for (int i = 0; i < numbersToPop; i++)
            {
                if (stack.Count == 0)
                {
                    break;
                }
                
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (stack.Contains(numberToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine($"{stack.Min()}");
            }
          

            
        }
    }
}
