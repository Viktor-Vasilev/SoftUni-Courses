using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            double totalMoney = 0;

            while (command != "Start")
            {
                double inputMoney = double.Parse(command);

                if (inputMoney == 0.1 || inputMoney == 0.2 || inputMoney == 0.5 || inputMoney == 1 || inputMoney == 2)
                {
                    totalMoney += inputMoney;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {inputMoney}");
                }
               
                command = Console.ReadLine();
            }

            if (command == "Start")
            {
                string product = Console.ReadLine().ToLower();
                while (product != "end")
                {
                    if (product == "nuts" || product == "water" || product == "crisps" || product == "soda" || product == "coke")
                    {                      
                        if (product == "nuts")
                        {
                            if (totalMoney >= 2)
                            {
                                totalMoney -= 2;
                                Console.WriteLine($"Purchased {product}");
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                        }
                        else if (product == "water")
                        {
                            if (totalMoney >= 0.7)
                            {
                                totalMoney -= 0.7;
                                Console.WriteLine($"Purchased {product}");
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                        }
                        else if (product == "crisps")
                        {
                            if (totalMoney >= 1.5)
                            {
                                totalMoney -= 1.5;
                                Console.WriteLine($"Purchased {product}");
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                        }
                        else if (product == "soda")
                        {
                            if (totalMoney >= 0.8)
                            {
                                totalMoney -= 0.8;
                                Console.WriteLine($"Purchased {product}");
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                        }
                        else if (product == "coke")
                        {
                            if (totalMoney >= 1)
                            {
                                totalMoney -= 1;
                                Console.WriteLine($"Purchased {product}");
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid product");
                    }
                    
                    product = Console.ReadLine().ToLower();
                }

                if (product == "end")
                {
                    Console.WriteLine($"Change: {totalMoney:F2}");
                }
            }

        }
    }
}
