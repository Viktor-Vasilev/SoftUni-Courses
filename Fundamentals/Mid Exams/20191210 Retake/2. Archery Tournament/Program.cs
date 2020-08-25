using System;
using System.Linq;
using System.Collections.Generic;

namespace _20191210_Retake_2._Archery_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split('|').Select(int.Parse).ToList();

            int points = 0;
            int startingIndex = 0;
            int length = 0;

            string command = Console.ReadLine();
           
            while (true)
            {

                if (command == "Game over")
                {
                    break;
                }
                else if (command == "Reverse")
                {
                    targets.Reverse();
                    command = Console.ReadLine(); // за да не се счупи веднага трябва да се прочете нова команда
                    continue;
                }

                string[] temp = command.Split(); //split by spaces
                string[] indexes = temp[1].Split('@'); //split by @

                if (indexes[0] == "Left")
                {

                    startingIndex = int.Parse(indexes[1]);
                    length = int.Parse(indexes[2]);

                    // if the index is valid
                    if (startingIndex >= 0 && startingIndex <= targets.Count - 1)
                    {
                        //while we are going to the target index
                        while (length != 0)
                        {

                            if (startingIndex > 0) //if it's not on the first index
                            {
                                startingIndex--;
                                length--;
                            }
                            else if (startingIndex == 0) //if it's on the first index
                            {
                                startingIndex = targets.Count - 1;
                                length--;
                            }
                        }

                        if (targets[startingIndex] >= 5) //if there is enough points
                        {
                            targets[startingIndex] -= 5;
                            points += 5;
                        }
                        else //if there isn't is enough points
                        {
                            points += targets[startingIndex];
                            targets[startingIndex] = 0;
                        }

                    }


                }
                else if (indexes[0] == "Right")
                {

                    startingIndex = int.Parse(indexes[1]);
                    length = int.Parse(indexes[2]);

                    // if the index is valid
                    if (startingIndex >= 0 && startingIndex <= targets.Count - 1)
                    {
                        //while we are going to the target index
                        while (length != 0)
                        {


                            if (startingIndex < targets.Count - 1)// if it's not on the last index
                            {
                                startingIndex++;
                                length--;
                            }
                            else if (startingIndex == targets.Count - 1) //// if it's on the last index
                            {
                                startingIndex = 0;
                                length--;
                            }
                        }

                        if (targets[startingIndex] >= 5)
                        {
                            targets[startingIndex] -= 5;
                            points += 5;
                        }
                        else
                        {
                            points += targets[startingIndex];
                            targets[startingIndex] = 0;
                        }
                    }

                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" - ", targets));
            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");




        }
    }
}
