using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20190724_Preparation_01_Concert
{
    class Program
    {
        static void Main()
        {
            string command = Console.ReadLine();

            Dictionary<string, List<string>> bandMembers = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandTime = new Dictionary<string, int>();

            while (command != "start of concert")
            {
                string[] splitted = command.Split("; ");

                string bandName = splitted[1];

                if (command.Contains("Add"))
                {
                    string membersAll = splitted[2];
                    string[] members = membersAll.Split(", ");

                    if (!bandMembers.ContainsKey(bandName))
                    {
                        bandMembers.Add(bandName, new List<string>());

                        for (int i = 0; i < members.Length; i++)
                        {
                            bandMembers[bandName].Add(members[i]);
                        }

                        bandTime.Add(bandName, 0);
                    }
                    else if (bandMembers.ContainsKey(bandName))
                    {
                        for (int i = 0; i < members.Length; i++)
                        {
                            if (!bandMembers[bandName].Contains(members[i]))
                            {
                                bandMembers[bandName].Add(members[i]);
                            }
                        }
                    }

                }
                else if (command.Contains("Play"))
                {
                    int time = int.Parse(splitted[2]);

                    if (bandMembers.ContainsKey(bandName))
                    {
                        bandTime[bandName] += time;
                    }
                    else if (!bandMembers.ContainsKey(bandName))
                    {
                        bandMembers.Add(bandName, new List<string>());
                        bandTime.Add(bandName, time);
                    }
                }

                command = Console.ReadLine(); ;
            }

            int totalTime = bandTime.Sum(x => x.Value);

            Console.WriteLine($"Total time: {totalTime}");

            foreach (var band in bandTime.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }

            string finalInput = Console.ReadLine();

            Console.WriteLine(finalInput);

            foreach (var member in bandMembers[finalInput])
            {
                Console.WriteLine($"=> {member}");
            }

            //string input = Console.ReadLine();

            //Dictionary<string, List<string>> bands = new Dictionary<string, List<string>>();

            //Dictionary<string, int> playTime = new Dictionary<string, int>();

            //int totalTime = 0;

            //while (input != "start of concert")
            //{
            //    string[] args = input.Split("; ");

            //    string command = args[0];
            //    string name = args[1];

            //    if (command == "Add")
            //    {
            //        List<string> members = args[2].Split(", ").ToList();

            //        if (!bands.ContainsKey(name))
            //        {
            //            bands.Add(name, members);
            //        }
            //        else
            //        {
            //            foreach (var member in members)
            //            {
            //                if(!bands[name].Contains(member))
            //                {
            //                    bands[name].Add(member);
            //                }
            //            }
            //        }

            //    }
            //    else
            //    {
            //        int time = int.Parse(args[2]);

            //        totalTime += time;

            //        if (!playTime.ContainsKey(name))
            //        {
            //            playTime.Add(name, time);
            //        }
            //        else
            //        {
            //            playTime[name] += time;
            //        }

            //    }

            //    input = Console.ReadLine();
            //}

            //Console.WriteLine($"Total time: {totalTime}");
            //// Console.WriteLine($"Total time: {playTime.Values.Sum}"); - по-хитро е -> без да се прави променлива и все път да се добавя!!!

            //foreach (var band in playTime.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            //{
            //    Console.WriteLine($"{band.Key} -> {band.Value}");
            //}

            //string finalBand = Console.ReadLine();

            //Console.WriteLine(finalBand);

            //foreach (var member in bands[finalBand])
            //{
            //    Console.WriteLine($"=> {member}");
            //}

        }
    }
}
