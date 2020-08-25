using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_Exer_02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();

            //string resource = " ";

            //Dictionary<string, int> resources = new Dictionary<string, int>();

            //int row = 1;

            //while (input != "stop")
            //{
            //    if (row % 2 != 0)
            //    {
            //        resource = input;

            //        if (!resources.ContainsKey(resource))
            //        {
            //            resources.Add(resource, 0);
            //        }
            //    }
            //    else
            //    {
            //        resources[resource] += int.Parse(input);
            //    }

            //    row++;

            //    input = Console.ReadLine();
            //}

            //foreach (var resourcee in resources)
            //{
            //    Console.WriteLine($"{resourcee.Key} -> {resourcee.Value}");
            //}

            Dictionary<string, int> resourceQuantity = new Dictionary<string, int>();

            while (true)
            {
                string resource = Console.ReadLine();
                if (resource == "stop")
                {
                    break;
                }
                int quantity = int.Parse(Console.ReadLine());

                if (resourceQuantity.ContainsKey(resource))
                {
                    resourceQuantity[resource] += quantity;
                }
                else
                {
                    resourceQuantity.Add(resource, quantity);
                    
                }


            }

            foreach (var pair in resourceQuantity)
            {
                Console.WriteLine(pair.Key + " -> " + pair.Value);
            }

        }
    }
}
