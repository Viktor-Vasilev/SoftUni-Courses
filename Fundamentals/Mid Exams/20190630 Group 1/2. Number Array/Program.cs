using System;
using System.Linq;
using System.Collections.Generic;

namespace _20190630_Group_1_Number_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(String.Join(" ", list));

            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }
                else if (input[0] == "Switch")
                {
                    int index = int.Parse(input[1]);

                    if (index >= 0 && index <= list.Count - 1)
                    {
                        int number = list[index];
                        list[index] = number - (number * 2);
                    }
                    
                }
                else if (input[0] == "Change")
                {
                    int index = int.Parse(input[1]);
                    int value = int.Parse(input[2]);

                    if (index >=0 && index <= list.Count - 1)
                    {
                        list[index] = value;
                    }
                }
                else if (input[1] == "Negative")
                {
                    int sum = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        int currentNumber = list[i];
                        if (currentNumber < 0)
                        {
                            sum += currentNumber;
                        }

                    }
                    Console.WriteLine(sum);
                }
                else if (input[1] == "Positive")
                {
                    int sum = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        int currentNumber = list[i];
                        if (currentNumber > 0)
                        {
                            sum += currentNumber;
                        }

                    }
                    Console.WriteLine(sum);





                }
                else if (input[1] == "All")
                {
                    Console.WriteLine(list.Sum());
                }


            }

            Console.WriteLine(string.Join(" ", list.Where(x => x >= 0)));

        }
    }
}
