using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace _20190806_Retake_2._Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> myList = Console.ReadLine().Split('|').ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "Yohoho!")
                {
                    break;
                }
                else if (command[0] == "Loot")
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        if (myList.Contains(command[i]) == false)
                        {
                            myList.Insert(0, command[i]);
                        }
                    }
                }
                else if (command[0] == "Drop")
                {
                    int index = int.Parse(command[1]);

                    if (index >= 0 && index <= myList.Count - 1)
                    {
                        string item = myList[index];
                        myList.RemoveAt(index);
                        myList.Add(item);

                    }
                    else
                    {
                        continue;
                    }


                }
                else if (command[0] == "Steal")
                {
                    int count = int.Parse(command[1]);

                    if (count > myList.Count)
                    {
                        count = myList.Count;
                    }

                    List<string> newList = new List<string>();

                    for (int i = 0; i < count; i++)
                    {
                        newList.Add(myList[myList.Count - 1]);
                        myList.Remove(myList[myList.Count - 1]);

                    }

                    newList.Reverse();

                    Console.WriteLine(string.Join(", ", newList));
                }
            }

            double sum = 0;

            if (myList.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
                return;
            }
            else
            {
                for (int i = 0; i < myList.Count; i++)
                {
                    sum += myList[i].Count();
                }
            }
            double averageGain = sum / myList.Count();

            Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");

        }
    }
}
