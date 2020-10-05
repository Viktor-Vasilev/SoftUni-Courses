using System;
using System.Collections.Generic;
using System.Linq;

namespace _20190623_01._Spaceship_Crafting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquidsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] itemsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Dictionary<string, int> materials = new Dictionary<string, int>
            {
                 {"Glass", 0 },
                {"Aluminium", 0},
                {"Lithium", 0},
                {"Carbon fiber", 0}
            };

            Queue<int> liquids = new Queue<int>(liquidsInput);
            Stack<int> items = new Stack<int>(itemsInput);

            while (liquids.Any() && items.Any())
            {
                int currentLiquid = liquids.Peek();
                int currentItem = items.Peek();

                if (currentLiquid + currentItem == 25)
                {
                    materials["Glass"]++;
                    liquids.Dequeue();
                    items.Pop();
                }
                else if (currentLiquid + currentItem == 50)
                {
                    materials["Aluminium"]++;
                    liquids.Dequeue();
                    items.Pop();
                }
                else if (currentLiquid + currentItem == 75)
                {
                    materials["Lithium"]++;
                    liquids.Dequeue();
                    items.Pop();
                }
                else if (currentLiquid + currentItem == 100)
                {
                    materials["Carbon fiber"]++;
                    liquids.Dequeue();
                    items.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    items.Pop();
                    items.Push(currentItem + 3);
                }               

            }

            bool success = false;

            if (materials["Glass"] > 0 && materials["Aluminium"] > 0 && materials["Lithium"] > 0 && materials["Carbon Fiber"] > 0)
            {
                success = true;
            }

            if (success)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (liquids.Any())
            {
                Console.WriteLine($"Liquids left: {String.Join(", ", liquids)} ");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (items.Any())
            {
                Console.WriteLine($"Liquids left: {String.Join(", ", items)} ");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            foreach (var material in materials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

        }
    }
}
