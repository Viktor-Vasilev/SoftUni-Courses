using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace _20190630_Group_2_3._Froggy_Squad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> frogs = Console.ReadLine().Split().ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "Join")
                {
                    string newFrog = command[1];
                    frogs.Add(newFrog);
                }
                else if (command[0] == "Jump")
                {
                    string newFrog = command[1];
                    int index = int.Parse(command[2]);

                    if (index >= 0 && index < frogs.Count)
                    {
                        frogs.Insert(index, newFrog);
                    }
                }
                else if (command[0] == "Dive")
                {                    
                    int index = int.Parse(command[1]);

                    if (index >= 0 && index < frogs.Count)
                    {
                        frogs.RemoveAt(index);
                    }

                }
                else if (command[0] == "First")
                {
                    int count = int.Parse(command[1]);
                    List<string> newListOfFrogs = new List<string>();

                    for (int i = 0; i < frogs.Count; i++)
                    {
                        newListOfFrogs.Add(frogs[i]);
                        count--;

                        if (count == 0)
                        {
                            break;
                        }
                    }

                    Console.WriteLine(String.Join(" ", newListOfFrogs));
                }
                else if (command[0] == "Last")
                {
                    int count = int.Parse(command[1]);
                    List<string> newListOfFrogs = new List<string>();

                    frogs.Reverse();
                    for (int i = 0; i < frogs.Count; i++)
                    {
                        newListOfFrogs.Add(frogs[i]);
                        count--;

                        if (count == 0)
                        {
                            break;
                        }
                    }

                    newListOfFrogs.Reverse();

                    frogs.Reverse();


                    Console.WriteLine(String.Join(" ", newListOfFrogs));

                    // ИЛИ:

                    //int count = int.Parse(command[1]);
                    //List<string> newListOfFrogs = new List<string>();


                    //if (count > frogs.Count)
                    //{
                    //    count = frogs.Count;
                    //}


                    //for (int i = frogs.Count - 1; i >= 0; i--)
                    //{
                    //    count--;
                    //    newListOfFrogs.Add(frogs[i]);

                    //    if (count == 0)
                    //    {
                    //        break;
                    //    }
                    //}

                    //newListOfFrogs.Reverse();





                } // lol обръщаме листа, добавяме ги като във First, после обръщаме и двата листа - GG
                else if (command[0] == "Print")
                {
                    if (command[1] == "Normal")
                    {
                        Console.WriteLine($"Frogs: {String.Join(" ", frogs)}");
                        return;
                    }
                    else if (command[1] == "Reversed")
                    {
                        frogs.Reverse();
                        Console.WriteLine($"Frogs: {String.Join(" ", frogs)}");
                        return;
                    }
                }
            }
        }
    }
}
