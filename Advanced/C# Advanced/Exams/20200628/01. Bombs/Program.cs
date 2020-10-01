using System;
using System.Collections.Generic;
using System.Linq;

namespace _20200628_01._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputEffects = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] inputCasings = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> effects = new Queue<int>(inputEffects);
            Stack<int> casings = new Stack<int>(inputCasings);

            Dictionary<string, int> madeBombs = new Dictionary<string, int>
            {
                {"Datura Bombs", 0},
                {"Cherry Bombs", 0},
                {"Smoke Decoy Bombs", 0}
            };

            bool success = false;

            while (effects.Any() && casings.Any())
            {
                int currentEffect = effects.Peek();
                int currentCasing = casings.Peek();

                int currentSum = currentEffect + currentCasing;

                if (currentSum == 40 || currentSum == 60 || currentSum == 120)
                {
                    if (currentSum == 40)
                    {
                        effects.Dequeue();
                        casings.Pop();
                        madeBombs["Datura Bombs"]++;
                    }
                    else if (currentSum == 60)
                    {
                        effects.Dequeue();
                        casings.Pop();
                        madeBombs["Cherry Bombs"]++;
                    }
                    else if (currentSum == 120)
                    {
                        effects.Dequeue();
                        casings.Pop();
                        madeBombs["Smoke Decoy Bombs"]++;
                    }

                    

                    if (madeBombs["Datura Bombs"] >= 3 && madeBombs["Cherry Bombs"] >= 3 && madeBombs["Smoke Decoy Bombs"] >= 3)
                    {                       
                        success = true;
                        break;
                    }
                }
                else
                {
                    casings.Push(casings.Pop() - 5);
                }

            }

            if (success)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Any())
            {
                Console.WriteLine($"Bomb Effects: {String.Join(", ", effects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (casings.Any())
            {
                Console.WriteLine($"Bomb Casings: {String.Join(", ", casings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in madeBombs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }

        }
    }
}
