using System;
using System.Collections.Generic;

namespace _20190224_01._Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallCapacity = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<string> elements = new Stack<string>(input);

            Queue<string> halls = new Queue<string>();

            List<int> allGroups = new List<int>();

            int currentCapacity = 0;

            while (elements.Count > 0)
            {
                string currentElement = elements.Pop();

                bool isNumber = int.TryParse(currentElement, out int parsedNumber);

                if (!isNumber) // ако не е число, значи е нова зала и я добавяме
                {
                    halls.Enqueue(currentElement);
                }
                else  // подават ни число
                {
                    if (halls.Count == 0) // проверяваме дали има зали, в които да добавяме
                    {
                        continue;
                    }
                    
                    if (currentCapacity + parsedNumber > hallCapacity) // ако има зали, ако текущата зала не може да поеме всички я печатаме и махаме и после зануляваме
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", allGroups)}");
                        allGroups.Clear();
                        currentCapacity = 0;
                    }

                    if (halls.Count > 0) // ако имаме зали и с текущия вход не влизаме в горната проверка
                    {
                        allGroups.Add(parsedNumber);
                        currentCapacity += parsedNumber;
                    }


                }
            }

            // Друго решение, с речник:
          
            //var hallMaxCapacity = int.Parse(Console.ReadLine());
            //var hallsAndPeople = new Dictionary<string, List<int>>();
            //var input = new Stack<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            //var halls = new Queue<string>();

            //while (input.Any())
            //{
            //    var currentChar = input.Peek();

            //    if (!char.IsDigit(currentChar[0]))
            //    {

            //        hallsAndPeople[currentChar] = new List<int>();
            //        halls.Enqueue(currentChar);
            //        input.Pop();
            //        continue;
            //    }
            //    if (hallsAndPeople.Count == 0)
            //    {
            //        input.Pop();
            //        continue;
            //    }

            //    foreach (var hall in hallsAndPeople)
            //    {

            //        if (hall.Value.Sum() + int.Parse(currentChar) <= hallMaxCapacity)
            //        {
            //            hallsAndPeople[hall.Key].Add(int.Parse(currentChar));
            //            input.Pop();
            //            break;
            //        }

            //        if (hall.Value.Sum() + int.Parse(currentChar) >= hallMaxCapacity && halls.Any())
            //        {
            //            Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", hall.Value)}");
            //            hallsAndPeople.Remove(hall.Key);
            //        }

            //        break;

            //    }
            //}

        }
    }
}
