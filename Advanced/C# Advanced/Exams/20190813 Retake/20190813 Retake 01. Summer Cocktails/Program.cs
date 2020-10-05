using System;
using System.Collections.Generic;
using System.Linq;

namespace _20190813_Retake_01._Summer_Cocktails
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] inputIngredient = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] inputFreshnessLevel = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> ingredients = new Queue<int>(inputIngredient);

            Stack<int> freshnessLevel = new Stack<int>(inputFreshnessLevel);

            Dictionary<string, int> cocktails = new Dictionary<string, int>()
                {
                    { "Mimosa" , 0 },
                    { "Daiquiri" , 0 },
                    { "Sunshine" , 0 },
                    { "Mojito" , 0 }
                };

            while (ingredients.Any() && freshnessLevel.Any())
            {
                int currentIngredient = ingredients.Peek();
                int currentFreshnessLevel = freshnessLevel.Peek();

                if (currentIngredient == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                ingredients.Dequeue();
                freshnessLevel.Pop();

                if (currentIngredient * currentFreshnessLevel == 150)
                {
                    cocktails["Mimosa"]++;
                   
                }
                else if (currentIngredient * currentFreshnessLevel == 250)
                {
                    cocktails["Daiquiri"]++;
                   
                }
                else if (currentIngredient * currentFreshnessLevel == 300)
                {
                    cocktails["Sunshine"]++;
                   
                }
                else if (currentIngredient * currentFreshnessLevel == 400)
                {
                    cocktails["Mojito"]++;
                    
                }
                else
                {                 
                    ingredients.Enqueue(currentIngredient + 5);                   
                }
            }

            bool success = true;

            foreach (var cocktail in cocktails)
            {
                if (cocktail.Value == 0)
                {
                    success = false;
                    break;
                }
            }

            Dictionary<string, int> readyCocktails = cocktails.Where(x => x.Value != 0).ToDictionary(a => a.Key, b => b.Value);

            if (success)
            {
                Console.WriteLine("It's party time! The cocktails are ready!");

                PrintIngredientSumIfAny(ingredients);
                PrintCocktails(readyCocktails);
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");

                PrintIngredientSumIfAny(ingredients);
                PrintCocktails(readyCocktails);
            }



        }

        private static void PrintCocktails(Dictionary<string, int> readyCocktails)
        {
            foreach (var cocktail in readyCocktails.OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {cocktail.Key} --> {cocktail.Value}");
            }
        }

        private static void PrintIngredientSumIfAny(Queue<int> ingredient)
        {
            if (ingredient.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredient.Sum()}");
            }
        }


    }
}
