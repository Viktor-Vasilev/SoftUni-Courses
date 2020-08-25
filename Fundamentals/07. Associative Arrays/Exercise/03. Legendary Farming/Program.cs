using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_Exer_03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, int> materials = new Dictionary<string, int>();
            //materials["motes"] = 0;
            //materials.Add("fragments", 0);
            //materials.Add("shards", 0);
            //Dictionary<string, int> junks = new Dictionary<string, int>();

            //while (true)
            //{
            //    string[] input = Console.ReadLine().Split();

            //    bool reachedNeeded = false;


            //    for (int i = 0; i < input.Length; i += 2) //!!!!!!
            //    {
            //        int quantity = int.Parse(input[i]);

            //        string material = input[i + 1].ToLower();

            //        if (material == "shards" || material == "fragments" || material == "motes")
            //        {
            //            materials[material] += quantity;

            //            if (materials[material] >= 250)
            //            {
            //                materials[material] -= 250;

            //                if (material == "shards")
            //                {
            //                    Console.WriteLine($"Shadowmourne obtained!");
            //                }
            //                else if (material == "fragments")
            //                {
            //                    Console.WriteLine($"Valanyr obtained!");
            //                }
            //                else
            //                {
            //                    Console.WriteLine($"Dragonwrath obtained!");
            //                }

            //                reachedNeeded = true;

            //                break;
            //            }
            //        }
            //        else
            //        {
            //            if (junks.ContainsKey(material) == false)
            //            {
            //                junks[material] = 0; // !!!!!!!
            //            }

            //            junks[material] += quantity;

            //        }
            //    }

            //    if (reachedNeeded)
            //    {
            //        break;
            //    }
            //}
            //Dictionary<string, int> filteredKeyMaterials = materials
            //    .OrderByDescending(kvp => kvp.Value)
            //    .ThenBy(kvp => kvp.Key)
            //    .ToDictionary(a => a.Key, a => a.Value);
            //foreach (var kvp in filteredKeyMaterials)
            //{
            //    string material = kvp.Key;
            //    int quantity = kvp.Value;
            //    Console.WriteLine($"{material}: {quantity}");
            //}
            //foreach (var kvp in junks.OrderBy(kvp => kvp.Key))
            //{
            //    string material = kvp.Key;
            //    int quantity = kvp.Value;
            //    Console.WriteLine($"{material}: {quantity}");
            //}

            Dictionary<string, int> materials = new Dictionary<string, int>();
            materials.Add("shards", 0);
            materials.Add("fragments", 0);
            materials.Add("motes", 0);

            Dictionary<string, int> junks = new Dictionary<string, int>();

            bool isObtainable = false;

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    if (materials.ContainsKey(material))
                    {
                        materials[material] += quantity;

                        if (materials[material] >= 250)
                        {

                            if (material == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            else if (material == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                            }
                            else if (material == "motes")
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }

                            materials[material] -= 250;
                            isObtainable = true;
                            break;

                        }

                    }
                    else
                    {
                        if (junks.ContainsKey(material))
                        {
                            junks[material] += quantity;
                        }
                        else
                        {
                            junks.Add(material, quantity);
                        }
                    }

                }

                if (isObtainable)
                {
                    break;
                }

            }

            foreach (var pair in materials.OrderByDescending(pair => pair.Value).ThenBy(pair => pair.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            foreach (var pair in junks.OrderBy(pair => pair.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

        }
    }
}
