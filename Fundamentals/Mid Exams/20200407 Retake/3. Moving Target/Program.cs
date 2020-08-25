using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace _20200407_Retake_3._Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "End")
                {
                    break;
                }
                else if (command[0] == "Shoot")
                {
                    int index = int.Parse(command[1]);
                    int power = int.Parse(command[2]);

                    if (index >= 0 && index < targets.Count)
                    {
                        targets[index] -= power;

                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }

                }
                else if (command[0] == "Add")
                {
                    int index = int.Parse(command[1]);
                    int value = int.Parse(command[2]);

                    if (index >= 0 && index < targets.Count)
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }

                }
                else if (command[0] == "Strike")
                {
                    int index = int.Parse(command[1]);
                    int radius = int.Parse(command[2]);

                    int startingLeftRadius = index - radius;
                    int endingRightRadius = index + radius;

                    if (startingLeftRadius < 0 || endingRightRadius >= targets.Count)
                    {
                        Console.WriteLine("Strike missed!");
                    }
                    else
                    {
                        targets.RemoveRange(startingLeftRadius, endingRightRadius - startingLeftRadius + 1);
                    }
                }
            }
            Console.WriteLine(String.Join("|", targets));
        }
        // ако се иска да не е Strike missed, а да порази до началото или края:
//         else if (command[0] == "Strike")
//            {
//                int index = int.Parse(command[1]);
//        int radius = int.Parse(command[2]);

//        int startingLeftRadius = index - radius;
//        int endingRightRadius = index + radius;

//                if (startingLeftRadius< 0)
//                {
//                    startingLeftRadius = 0;
//                }
//                if (endingRightRadius >= targets.Count)
//                {
//                    endingRightRadius = targets.Count - 1;
//                }

//        targets.RemoveRange(startingLeftRadius, endingRightRadius - startingLeftRadius + 1);

    }
}
