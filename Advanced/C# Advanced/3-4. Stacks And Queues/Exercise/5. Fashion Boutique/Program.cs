using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Exer_5._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int numberOfRacks = 1;

            Stack<int> stack = new Stack<int>(clothes);

            int capacityOfTheRack = int.Parse(Console.ReadLine());

            int sum = 0;

            while (stack.Count > 0)
            {
                int clothWorth = stack.Pop();

                sum += clothWorth;

                if (sum > capacityOfTheRack)
                {
                    sum = clothWorth;
                    numberOfRacks++;
                }
            }
           

            Console.WriteLine(numberOfRacks);

        }
    }
}
