using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace _2._Exer_04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "End")
                {
                    break;
                }
                else if (command[0] == "Add")
                {
                    int number = int.Parse(command[1]);
                    input.Add(number);
                }
                else if (command[0] == "Insert")
                {
                    int number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);

                    if (index < 0 || index >= input.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        input.Insert(index, number);
                    }
                    
                }
                else if (command[0] == "Remove")
                {
                   int index = int.Parse(command[1]);
                    if (index < 0 || index >= input.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        input.RemoveAt(index);
                    }
                }
                else if (command[0] == "Shift")
                {
                    if (command[1] == "left")
                    {
                        int count = int.Parse(command[2]);
                        for (int i = 0; i < count; i++)  // преместване на елемент накрая
                        {
                            int firstNum = input[0];  // копиране на първия елемент
                            input.Add(firstNum);        // добавяме го накрая
                            input.RemoveAt(0);        // изтриваме го от първа позиция

                        }
                    }
                    else if(command[1] == "right")
                    {
                        int count = int.Parse(command[2]); // преместване на елемент в началото
                        for (int i = 0; i < count; i++)
                        {
                            int lastNum = input[input.Count - 1]; // копиране на последния елемент
                            input.Insert(0, lastNum);      // слагаме в началото
                            input.RemoveAt(input.Count - 1);   // изтриваме го от края;
                        }
                    }
                }
                
            }

            Console.WriteLine(String.Join(" ", input));

        }
    }
}
