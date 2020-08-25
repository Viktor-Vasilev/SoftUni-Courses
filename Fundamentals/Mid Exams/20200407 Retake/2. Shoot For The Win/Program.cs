using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace _20200407_Retake_2._Shoot_For_The_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();

            int count = 0;

            while (true)
            {
                string command = Console.ReadLine();

               

                if (command == "End")
                {
                    break;
                }
                else
                {
                    int targetIndex = int.Parse(command);

                    if (targetIndex >= 0 && targetIndex < targets.Count)
                    {
                        for (int i = 0; i < targets.Count; i++)
                        {
                            int temp = targets[targetIndex];

                            if (targets[i] != -1 && i != targetIndex)
                            {
                                if (targets[i] > temp)
                                {
                                    targets[i] -= temp;
                                }
                                else if (targets[i] <= temp)
                                {
                                    targets[i] += temp;
                                }
                            }

                        }

                        targets[targetIndex] = -1;
                        count++;

                    }

                }
               
            }

            Console.WriteLine($"Shot targets: {count} ->" + " " + string.Join(' ', targets));
        }
    }
}
