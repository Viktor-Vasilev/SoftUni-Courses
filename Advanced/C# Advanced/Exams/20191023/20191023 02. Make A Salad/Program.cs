using System;
using System.Collections.Generic;
using System.Linq;

namespace _20191023_02._Make_A_Salad
{
    class Program
    {
        static void Main(string[] args)
        {          

            string[] inputVegetables = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int[] inputSalads = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<string> vegetables = new Queue<string>(inputVegetables);

            Stack<int> salads = new Stack<int>(inputSalads);

            List<int> madeSalads = new List<int>();

            int leftCalories = 0;

            while (vegetables.Any() && salads.Any())
            {
                string currentVegetable = vegetables.Dequeue();

                int currentSalad = salads.Peek();
                
                if (currentSalad == 0)
                {
                    continue;
                }

                int currentCalories = 0;

                if (currentVegetable == "tomato")
                {
                    currentCalories = 80;
                }
                else if (currentVegetable == "carrot")
                {
                    currentCalories = 136;
                }
                else if (currentVegetable == "lettuce")
                {
                    currentCalories = 109;
                }
                else if (currentVegetable == "potato")
                {
                    currentCalories = 215;
                }


                if (leftCalories == 0)
                {
                    leftCalories = currentSalad - currentCalories;

                    if (currentCalories >= currentSalad)
                    {
                        madeSalads.Add(currentSalad);

                        salads.Pop();

                        leftCalories = 0;
                    }
                }
                else
                {
                    if (currentCalories >= leftCalories)
                    {
                        madeSalads.Add(currentSalad);

                        salads.Pop();

                        leftCalories = 0;
                    }
                    else
                    {
                        leftCalories = leftCalories - currentCalories;
                    }
                }
            }

            if (leftCalories > 0 && salads.Any())
            {
                madeSalads.Add(salads.Pop());
            }

            Console.WriteLine(string.Join(" ", madeSalads));

            if (vegetables.Any())
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
            else if (salads.Any())
            {
                Console.WriteLine(string.Join(" ", salads));
            }

        }
    }
}
