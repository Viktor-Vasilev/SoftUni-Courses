using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_Exer_05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parking = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                string user = command[1];

                if (command[0] == "register")
                {
                    string licencePlateNumber = command[2];

                    if (!parking.ContainsKey(user))
                    {
                        parking.Add(user, licencePlateNumber);
                        Console.WriteLine($"{user} registered {licencePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licencePlateNumber}");
                    }
                }
                else if ((command[0] == "unregister"))
                {
                    if (!parking.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                    else
                    {
                        parking.Remove(user);
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                }


            }

            foreach (var user in parking)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }

            // с while

            //int n = int.Parse(Console.ReadLine());

            //Dictionary<string, string> parking = new Dictionary<string, string>();

            //while (n > 0)
            //{
            //    string[] command = Console.ReadLine().Split();

            //    if (command[0] == "register")
            //    {
            //        if (!parking.ContainsKey(command[1]))
            //        {
            //            parking.Add(command[1], command[2]);
            //            Console.WriteLine($"{command[1]} registered {command[2]} successfully");
            //        }
            //        else
            //        {
            //            Console.WriteLine($"ERROR: already registered with plate number {command[2]}");
            //        }


            //    }
            //    else if (command[0] == "unregister")
            //    {
            //        if (!parking.ContainsKey(command[1]))
            //        {
            //            Console.WriteLine($"ERROR: user {command[1]} not found");
            //        }
            //        else
            //        {
            //            parking.Remove(command[1]);
            //            Console.WriteLine($"{command[1]} unregistered successfully");
            //        }
            //    }


            //    n--;
            //}

            //foreach (var pair in parking)
            //{
            //    Console.WriteLine($"{pair.Key} => {pair.Value}");
            //}

        }
    }
}
