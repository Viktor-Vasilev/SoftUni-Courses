using System;
using System.Collections.Generic;

namespace _2._Exer_03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            SortedSet<string> elements = new SortedSet<string>();

            while (n > 0)
            {
                n--;

                string[] currentInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < currentInput.Length; i++)
                {
                    string currentElement = currentInput[i];

                    elements.Add(currentElement);
                }


            }

            foreach (var element in elements)
            {
                Console.Write($"{element} ");
            }

            //по яко решение, с ламбди!!!
            
            //SortedSet<string> chemicalElements = new SortedSet<string>();
            //int n = int.Parse(Console.ReadLine());

            //while (n-- > 0)
            //{
            //    string[] elements = Console.ReadLine().Split();
            //    elements.ToList().ForEach(x => chemicalElements.Add(x));
            //}

            //Console.WriteLine(String.Join(" ", chemicalElements));

        }
    }
}
