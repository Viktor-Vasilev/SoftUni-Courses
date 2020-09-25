using System;
using System.Collections.Generic;

namespace _1._Lab_06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carPlates = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] splitted = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string command = splitted[0];

                string carPlate = splitted[1];

                if (command == "IN")
                {
                    carPlates.Add(carPlate);
                }
                else
                {
                    carPlates.Remove(carPlate);
                }

                input = Console.ReadLine();
            }


            if (carPlates.Count > 0)
            {
                foreach (var carPlate in carPlates)
                {
                    Console.WriteLine(carPlate);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            

        }
    }
}
