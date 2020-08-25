using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace _2._Exer_02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "Delete")
                {
                    int numberToRemove = int.Parse(command[1]); 
                    input.RemoveAll(n => n == numberToRemove); // друг начин за триене на елементи с for loop - по надолу
                }

                if (command[0] == "Insert")
                {
                    int element = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    input.Insert(index, element);
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(String.Join(" ", input));

            //for (int i = 0; i < input.Count; i++)
            //{

            //    if (input[i] == numberToRemove)
            //    {
            //    input.RemoveAt(i);
            //    i--;
            //    }
            //}


        }

        
}
}
