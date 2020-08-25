using System;
using System.Linq;
using System.Collections.Generic;

namespace _00_MidExam_Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "end")
                {
                    break;
                }
                else if (command[0] == "swap")
                {
                    int index1 = int.Parse(command[1]);
                    int index2 = int.Parse(command[2]);

                    int temp = input[index1];
                    input[index1] = input[index2];
                    input[index2] = temp;

                }
                else if (command[0] == "multiply")
                {
                    int index1 = int.Parse(command[1]);
                    int index2 = int.Parse(command[2]);

                    int temp = input[index1] * input[index2];
                    input[index1] = temp;

                }
                else if (command[0] == "decrease")
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        input[i] -= 1;
                    }
                }

            }
            Console.WriteLine(String.Join(", ", input));

        }
    }
}
