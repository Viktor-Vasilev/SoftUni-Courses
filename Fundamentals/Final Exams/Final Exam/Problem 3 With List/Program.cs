using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> plants = new Dictionary<string, List<double>>();
            
            // 0 - rarity;
            // from 1 - ratings;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] splitted = input.Split("<->");

                string plant = splitted[0];

                int rarity = int.Parse(splitted[1]);

                if (!plants.ContainsKey(plant))
                {
                    plants.Add(plant, new List<double> { rarity });
                }
                else
                {
                    plants[plant][0] = rarity;
                }              
            }

            string command = Console.ReadLine();

            while (command != "Exhibition")
            {
                string[] splitted = command.Split(": ");

                if (command.Contains("Rate"))
                {                               
                    string flowerAndRating = splitted[1];

                    string[] flowerStats = flowerAndRating.Split(" - ");

                    string plant = flowerStats[0];

                    int rating = int.Parse(flowerStats[1]);

                    plants[plant].Add(rating);
                }
                else if (command.Contains("Update"))
                {
                    string flowerAndRarity = splitted[1];

                    string[] flowerStats = flowerAndRarity.Split(" - ");

                    string plant = flowerStats[0];

                    int rarity = int.Parse(flowerStats[1]);

                    plants[plant][0] = rarity;

                }
                else if (command.Contains("Reset"))
                {
                    string plant = splitted[1];

                    plants[plant].RemoveRange(1, plants[plant].Count - 1);
                }
                else
                {
                    Console.WriteLine("Error");
                }

                command = Console.ReadLine();
            }

            foreach (var plant in plants)
            {

                double rarity = plant.Value[0];

                plant.Value.RemoveAt(0);

                int count = plant.Value.Count;

                double sum = plant.Value.Sum();

                if (sum > 0)
                {
                    sum /= count;
                }
                plant.Value.Clear();
                plant.Value.Add(rarity);
                plant.Value.Add(sum);

            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plants.OrderByDescending(x => x.Value[0]).ThenByDescending(x => x.Value[1]).ToDictionary(x => x.Key, x => x.Value))
            {
                Console.WriteLine($"- {item.Key}; Rarity: {(int)item.Value[0]}; Rating: {item.Value[1]:f2}");
            }


        }
    }
}
