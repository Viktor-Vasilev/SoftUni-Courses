using System;
using System.Collections.Generic;
using System.Linq;

namespace _20191217_Retake_01._Santas_Present_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] materialsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] magicInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> magic = new Queue<int>(magicInput);
            Stack<int> material = new Stack<int>(materialsInput);

            Dictionary<string, int> craftedToys = new Dictionary<string, int>()
            {
                {"Doll", 0 },
                {"Bicycle", 0},
                {"Teddy bear", 0},
                {"Wooden train", 0}

            };

            while (magic.Count > 0 && material.Count > 0)
            {
                int currentMaterial = material.Peek();
                int currentMagic = magic.Peek();

                if (currentMaterial == 0 || currentMagic == 0)
                {
                    if (currentMaterial == 0)
                    {
                        material.Pop();
                    }
                    if (currentMagic == 0)
                    {
                        magic.Dequeue();
                    }                                
                    continue;
                }

                if (currentMaterial * currentMagic < 0)
                {                                  
                    material.Pop();
                    magic.Dequeue();
                    material.Push(currentMaterial + currentMagic);
                    continue;
                }

                if (currentMaterial * currentMagic == 150)
                {
                    material.Pop();
                    magic.Dequeue();
                    craftedToys["Doll"]++;
                }
                else if (currentMaterial * currentMagic == 250)
                {
                    material.Pop();
                    magic.Dequeue();
                    craftedToys["Wooden train"]++;
                }
                else if (currentMaterial * currentMagic == 300)
                {
                    material.Pop();
                    magic.Dequeue();
                    craftedToys["Teddy bear"]++;
                }
                else if (currentMaterial * currentMagic == 400)
                {
                    material.Pop();
                    magic.Dequeue();
                    craftedToys["Bicycle"]++;
                }
                else
                {
                    magic.Dequeue();
                    material.Push(material.Pop() + 15);
                }

            }


            bool success = false;

            if (craftedToys["Doll"] > 0 && craftedToys["Wooden train"] > 0 || craftedToys["Teddy bear"] > 0 && craftedToys["Bicycle"] > 0)
            {
                success = true;
            }

            if (success)
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (material.Count > 0)
            {
                Console.WriteLine($"Materials left: {string.Join(", ", material)}");
            }
            if (magic.Count > 0)
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magic)}");
            }

            foreach (var toy in craftedToys.OrderBy(x => x.Key))
            {
                if (toy.Value > 0)
                {
                    Console.WriteLine($"{toy.Key}: {toy.Value}");
                }
            }

            // Друго решение:
            //Stack<int> myStackMaterials = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            //Queue<int> myQueueMagicLevel = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

            //Dictionary<string, int> myDictionary = new Dictionary<string, int>();

            //while (myStackMaterials.Count > 0 && myQueueMagicLevel.Count > 0)
            //{
            //    if (myStackMaterials.Peek() == 0 || myQueueMagicLevel.Peek() == 0)
            //    {
            //        if (myStackMaterials.Peek() == 0)
            //        {
            //            myStackMaterials.Pop();
            //        }
            //        if (myQueueMagicLevel.Peek() == 0)
            //        {
            //            myQueueMagicLevel.Dequeue();
            //        }
            //        continue;
            //    }

            //    int result = myStackMaterials.Peek() * myQueueMagicLevel.Peek();

            //    if (result > 0)
            //    {
            //        switch (result)
            //        {
            //            case 150:
            //                if (myDictionary.ContainsKey("Doll"))
            //                {
            //                    myDictionary["Doll"] += 1;
            //                }
            //                else
            //                {
            //                    myDictionary.Add("Doll", 1);
            //                }
            //                myStackMaterials.Pop();
            //                myQueueMagicLevel.Dequeue();
            //                break;
            //            case 250:
            //                if (myDictionary.ContainsKey("Wooden train"))
            //                {
            //                    myDictionary["Wooden train"] += 1;
            //                }
            //                else
            //                {
            //                    myDictionary.Add("Wooden train", 1);
            //                }
            //                myStackMaterials.Pop();
            //                myQueueMagicLevel.Dequeue();
            //                break;
            //            case 300:
            //                if (myDictionary.ContainsKey("Teddy bear"))
            //                {
            //                    myDictionary["Teddy bear"] += 1;
            //                }
            //                else
            //                {
            //                    myDictionary.Add("Teddy bear", 1);
            //                }
            //                myStackMaterials.Pop();
            //                myQueueMagicLevel.Dequeue();
            //                break;
            //            case 400:
            //                if (myDictionary.ContainsKey("Bicycle"))
            //                {
            //                    myDictionary["Bicycle"] += 1;
            //                }
            //                else
            //                {
            //                    myDictionary.Add("Bicycle", 1);
            //                }
            //                myStackMaterials.Pop();
            //                myQueueMagicLevel.Dequeue();
            //                break;
            //            default:
            //                int tempMaterialValue = myStackMaterials.Pop() + 15;
            //                myStackMaterials.Push(tempMaterialValue);

            //                myQueueMagicLevel.Dequeue();
            //                break;
            //        }
            //    }
            //    else if (result < 0)
            //    {
            //        int sum = myStackMaterials.Pop() + myQueueMagicLevel.Dequeue();
            //        myStackMaterials.Push(sum);
            //    }
            //}

            //if ((myDictionary.ContainsKey("Doll") && myDictionary.ContainsKey("Wooden train")) || (myDictionary.ContainsKey("Teddy bear") && myDictionary.ContainsKey("Bicycle")))
            //{
            //    Console.WriteLine($"The presents are crafted! Merry Christmas!");
            //}
            //else
            //{
            //    Console.WriteLine("No presents this Christmas!");
            //}

            //if (myStackMaterials.Count > 0)
            //{
            //    Console.WriteLine("Materials left: " + string.Join(", ", myStackMaterials).ToString());
            //}
            //if (myQueueMagicLevel.Count > 0)
            //{
            //    Console.WriteLine("Magic left: " + string.Join(", ", myQueueMagicLevel).ToString());
            //}

            //myDictionary = myDictionary.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            //foreach (var item in myDictionary)
            //{
            //    Console.WriteLine($"{item.Key}: {item.Value}".ToString());
            //}

        }
    }
}
