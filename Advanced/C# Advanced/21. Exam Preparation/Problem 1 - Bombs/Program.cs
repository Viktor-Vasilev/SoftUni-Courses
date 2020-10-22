using System;
using System.Collections.Generic;
using System.Linq;

namespace _21._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] m = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Queue<int> effects = new Queue<int>(n);
            Stack<int> casings = new Stack<int>(m);

            Dictionary<string, int> madeBombs = new Dictionary<string, int>
            {
                {"Datura Bombs", 0 },
                {"Cherry Bombs", 0 },
                {"Smoke Decoy Bombs", 0 }
            };

            while (effects.Any() && casings.Any())
            {
                int currentEffect = effects.Peek();
                int currentCasing = casings.Peek();

                if (currentCasing + currentEffect == 40)
                {
                    effects.Dequeue();
                    casings.Pop();
                    madeBombs["Datura Bombs"]++;
                    if (madeBombs["Datura Bombs"] >= 3 && madeBombs["Cherry Bombs"] >= 3 && madeBombs["Smoke Decoy Bombs"] >= 3)
                    {
                        break;
                    }
                }
                else if (currentCasing + currentEffect == 60)
                {
                    effects.Dequeue();
                    casings.Pop();
                    madeBombs["Cherry Bombs"]++;
                    if (madeBombs["Datura Bombs"] >= 3 && madeBombs["Cherry Bombs"] >= 3 && madeBombs["Smoke Decoy Bombs"] >= 3)
                    {
                        break;
                    }
                }
                else if (currentCasing + currentEffect == 120)
                {
                    effects.Dequeue();
                    casings.Pop();
                    madeBombs["Smoke Decoy Bombs"]++;
                    if (madeBombs["Datura Bombs"] >= 3 && madeBombs["Cherry Bombs"] >= 3 && madeBombs["Smoke Decoy Bombs"] >= 3)
                    {
                        break;
                    }
                }
                else
                {
                    currentCasing -= 5;
                    casings.Pop();
                    casings.Push(currentCasing);
                }
            }

            if (madeBombs["Datura Bombs"] >= 3 && madeBombs["Cherry Bombs"] >= 3 && madeBombs["Smoke Decoy Bombs"] >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Any())
            {
                Console.WriteLine($"Bomb Effects: {String.Join(", ", effects)} ");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (casings.Any())
            {
                Console.WriteLine($"Bomb Casings: {String.Join(", ", casings)} ");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in madeBombs.OrderBy(a => a.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }

        }
    }
}
