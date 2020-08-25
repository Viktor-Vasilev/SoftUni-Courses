using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace _1._Lab_07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            bool isListChanged = false;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] tokens = line.Split();              

                if (tokens[0] == "Add")
                {
                    int numberToAdd = int.Parse(tokens[1]);
                    numbers.Add(numberToAdd);
                    isListChanged = true;
                }
                else if (tokens[0] == "Remove")
                {
                    int numberToRemove = int.Parse(tokens[1]);
                    numbers.Remove(numberToRemove);
                    isListChanged = true;
                }
                else if (tokens[0] == "RemoveAt")
                {
                    int indexToRemoveAt = int.Parse(tokens[1]);
                    numbers.RemoveAt(indexToRemoveAt);
                    isListChanged = true;
                }
                else if (tokens[0] == "Insert")
                {
                    int numberToInsert = int.Parse(tokens[1]);
                    int indexToInsert = int.Parse(tokens[2]);
                    numbers.Insert(indexToInsert, numberToInsert);
                    isListChanged = true;
                }
                else if (tokens[0] == "Contains")
                {
                    int numberToCheck = int.Parse(tokens[1]);
                    if (numbers.Contains(numberToCheck))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (tokens[0] == "PrintEven")
                {
                    List<int> result = new List<int>();
                    
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 == 0)
                        {
                            result.Add(numbers[i]);
                        }
                    }
                    Console.WriteLine(String.Join(" ", result));
                }
                else if (tokens[0] == "PrintOdd")
                {
                    List<int> result = new List<int>();

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 != 0)
                        {
                            result.Add(numbers[i]);
                        }
                    }
                    Console.WriteLine(String.Join(" ", result));
                }
                else if (tokens[0] == "GetSum")
                {
                    Console.WriteLine(numbers.Sum());
                }
                else if (tokens[0] == "Filter")
                {
                    string condition = tokens[1];
                    int number = int.Parse(tokens[2]);

                    if (condition == "<")
                    {
                        List <int> result = new List<int>();
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] < number)
                            {
                                result.Add(numbers[i]);
                            }
                        }
                        Console.WriteLine(String.Join(" ", result));

                    }
                    else if (condition == ">")
                    {
                        List<int> result = new List<int>();
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] > number)
                            {
                                result.Add(numbers[i]);
                            }
                        }
                        Console.WriteLine(String.Join(" ", result));
                    }
                    else if (condition == ">=")
                    {
                        List<int> result = new List<int>();
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] >= number)
                            {
                                result.Add(numbers[i]);
                            }
                        }
                        Console.WriteLine(String.Join(" ", result));
                    }
                    else if (condition == "<=")
                    {
                        List<int> result = new List<int>();
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] <= number)
                            {
                                result.Add(numbers[i]);
                            }
                        }
                        Console.WriteLine(String.Join(" ", result));
                    }

                }

            }
            if (isListChanged == true)
            {
                Console.WriteLine(String.Join(" ", numbers));
            }
        }
    }
}
