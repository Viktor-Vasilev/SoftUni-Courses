using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Exer_10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> cars = new List<string>();

            //Queue<string> queue = new Queue<string>();

            //int greenLight = int.Parse(Console.ReadLine());

            //int freeWindow = int.Parse(Console.ReadLine());

            //int passedCars = 0;

            //while (true)
            //{
            //    string input = Console.ReadLine();

            //    if (input == "END")
            //    {
            //        break;
            //    }

            //    if (input == "green")
            //    {
            //        int seconds = greenLight;

            //        while (seconds > 0 && queue.Count != 0)
            //        {
            //            string car = queue.Dequeue();

            //            cars.Add(car);

            //            seconds -= car.Length;

            //        }

            //        seconds = greenLight + freeWindow;

            //        foreach (string car in cars)
            //        {
            //            for (int i = 0; i < car.Length; i++)
            //            {
            //                seconds--;

            //                if (seconds < 0)
            //                {
            //                    Console.WriteLine("A crash happened!");
            //                    Console.WriteLine($"{car} was hit at {car[i]}.");
            //                    return;
            //                }
            //            }
            //        }

            //        passedCars += cars.Count;

            //        cars.Clear();
            //    }

            //    else
            //    {
            //        queue.Enqueue(input);
            //    }
            //}

            //Console.WriteLine("Everyone is safe.");
            //Console.WriteLine($"{passedCars} total cars passed the crossroads.");

            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> queueOfCars = new Queue<string>();

            bool isHitted = false;
            string hittedCarName = string.Empty;
            char hittedSymbol = '\0';
            int totalCars = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                if (input == "green")
                {
                    int currentGreenLight = greenLight;

                    while (currentGreenLight > 0 && queueOfCars.Count > 0)
                    {
                        string car = queueOfCars.Dequeue();
                        int carLenght = car.Length;

                        if (currentGreenLight - carLenght >= 0)
                        {
                            currentGreenLight -= carLenght;
                            totalCars++;
                        }
                        else // use freeWindow
                        {
                            currentGreenLight += freeWindow;

                            if (currentGreenLight - carLenght >= 0)
                            {
                                currentGreenLight -= carLenght;
                                totalCars++;
                                break;
                            }
                            else
                            {
                                isHitted = true;
                                hittedCarName = car;
                                hittedSymbol = car[currentGreenLight];
                                break;
                            }
                        }
                    }
                }
                else
                {
                    queueOfCars.Enqueue(input);
                }

                if (isHitted)
                {
                    break;
                }
            }

            if (isHitted)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{hittedCarName} was hit at {hittedSymbol}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCars} total cars passed the crossroads.");
            }

        }
    }
}
