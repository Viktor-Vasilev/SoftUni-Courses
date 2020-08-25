using System;

namespace _3._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {

            //double balance = double.Parse(Console.ReadLine());
            //string game = Console.ReadLine();
            //double expenses = 0.0;

            //while (game != "Game Time")
            //{
            //    double gamePrice = 0.0;
            //    switch (game)
            //    {
            //        case "OutFall 4":
            //            gamePrice = 39.99;
            //            break;
            //        case "CS: OG":
            //            gamePrice = 15.99;
            //            break;
            //        case "Zplinter Zell":
            //            gamePrice = 19.99;
            //            break;
            //        case "Honored 2":
            //            gamePrice = 59.99;
            //            break;
            //        case "RoverWatch":
            //            gamePrice = 29.99;
            //            break;
            //        case "RoverWatch Origins Edition":
            //            gamePrice = 39.99;
            //            break;
            //        default:
            //            Console.WriteLine("Not Found");
            //            game = Console.ReadLine();
            //            continue;
            //    }

            //    if (balance >= gamePrice)
            //    {
            //        Console.WriteLine($"Bought {game}");
            //        expenses += gamePrice;
            //        balance -= gamePrice;
            //    }
            //    else if (balance < gamePrice)
            //    {
            //        Console.WriteLine("Too Expensive");
            //    }

            //    if (balance == 0)
            //    {
            //        Console.WriteLine("Out of money!");
            //        return;
            //    }
            //    game = Console.ReadLine();
            //}

            //Console.WriteLine($"Total spent: ${expenses:F2}. Remaining: ${balance:F2}");

            double balance = double.Parse(Console.ReadLine());

            double copyOfBalance = balance;

            string command = Console.ReadLine();

            double totalSpent = 0;

            while (command != "Game Time")
            {
                if (command == "OutFall 4")
                {
                    if (balance >= 39.99)
                    {
                        Console.WriteLine($"Bought {command}");
                        balance -= 39.99;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "CS: OG")
                {
                    if (balance >= 15.99)
                    {
                        Console.WriteLine($"Bought {command}");
                        balance -= 15.99;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "Zplinter Zell")
                {
                    if (balance >= 19.99)
                    {
                        Console.WriteLine($"Bought {command}");
                        balance -= 19.99;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "Honored 2")
                {
                    if (balance >= 59.99)
                    {
                        Console.WriteLine($"Bought {command}");
                        balance -= 59.99;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "RoverWatch")
                {
                    if (balance >= 29.99)
                    {
                        Console.WriteLine($"Bought {command}");
                        balance -= 29.99;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "RoverWatch Origins Edition")
                {
                    if (balance >= 39.99)
                    {
                        Console.WriteLine($"Bought {command}");
                        balance -= 39.99;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }


                if (balance == 0)
                {
                    Console.WriteLine("Out of money !");
                    return;
                }

                command = Console.ReadLine();

            }

            totalSpent = copyOfBalance - balance;

            Console.WriteLine($"Total spent: ${totalSpent:F2}. Remaining: ${balance:F2}");


        }
    }
}
