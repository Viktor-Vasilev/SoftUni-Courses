using System;
using System.Linq;
using System.Collections.Generic;


namespace _20190630_Group_2_Task_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string[] line = Console.ReadLine().Split();

                if (line[0] == "End")
                {
                    break;
                }
                else if (line[0] == "Complete")
                {
                    int index = int.Parse(line[1]);

                    if (index >= 0 && index <= numbers.Count)
                    {
                        numbers.RemoveAt(index);
                        numbers.Insert(index, 0);
                    }
                }
                else if (line[0] == "Change")
                {
                    int index = int.Parse(line[1]);
                    int time = int.Parse(line[2]);

                    if (index >= 0 && index <= numbers.Count)
                    {
                        numbers.RemoveAt(index);
                        numbers.Insert(index, time);
                    }
                }
                else if (line[0] == "Drop")
                {
                    int index = int.Parse(line[1]);

                    if (index >= 0 && index <= numbers.Count)
                    {
                        numbers.RemoveAt(index);
                        numbers.Insert(index, -1);
                    }
                }
                else if (line[1] == "Completed")
                {
                    int sum = 0;

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        double currentNumber = numbers[i];
                        if (currentNumber == 0)
                        {
                            sum++;
                        }
                    }
                    Console.WriteLine(sum);

                }
                else if (line[1] == "Incomplete")
                {
                    int sum = 0;

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        double currentNumber = numbers[i];
                        if (currentNumber != 0)
                        {
                            sum++;
                        }
                    }
                    Console.WriteLine(sum);
                }
                else if (line[1] == "Dropped")
                {
                    int sum = 0;

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        double currentNumber = numbers[i];
                        if (currentNumber == -1)
                        {
                            sum++;
                        }
                    }
                    Console.WriteLine(sum);
                }
                

            }

            List<int> incomplete = numbers.FindAll(x => x > 0);
            Console.WriteLine(string.Join(" ", incomplete));


           

        }
    }
}
