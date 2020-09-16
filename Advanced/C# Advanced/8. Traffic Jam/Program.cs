using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Lab_8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string command = Console.ReadLine();

            int count = 0;

            while (true)
            {
                if (command == "end")
                {
                    break;
                }

                if (command == "green")
                {
                    for (int i = 0; i < n; i++)
                    {

                        if (cars.Count > 0)
                        {
                            count++;
                            Console.WriteLine($"{cars.Dequeue()} passed!"); 
                        }
                    }

                }
                else
                {
                    cars.Enqueue(command);
                }


                command = Console.ReadLine();
            }


            Console.WriteLine($"{count} cars passed the crossroads.");


        }
    }
}
