using System;

namespace _04._Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepCounter = 0;

            while (stepCounter < 10000)
            {
                string command = Console.ReadLine();
                if (command == "Going home")
                {
                    stepCounter += int.Parse(Console.ReadLine());

                    if (stepCounter >= 10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                    }
                    else
                    {
                        int differenceStep = 10000 - stepCounter;
                        Console.WriteLine($"{differenceStep} more steps to reach goal.");
                    }
                    break;
                }
                else
                {
                    stepCounter += int.Parse(command);
                    if (stepCounter >= 10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                    }
                }



            }


        }
    }
}
