using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0;

            double total = 0;

            switch (typeOfGroup)
            {
                case "Students":
                    {
                        if (day == "Friday")
                        {
                            price = 8.45;
                        }
                        else if (day == "Saturday")
                        {
                            price = 9.80;
                        }
                        else
                        {
                            price = 10.46;
                        }
                        break;
                    }
                case "Business":
                    {
                        if (day == "Friday")
                        {
                            price = 10.90;
                        }
                        else if (day == "Saturday")
                        {
                            price = 15.60;
                        }
                        else
                        {
                            price = 16.00;
                        }
                        break;
                    }
                case "Regular":
                    {
                        if (day == "Friday")
                        {
                            price = 15;
                        }
                        else if (day == "Saturday")
                        {
                            price = 20;
                        }
                        else
                        {
                            price = 22.50;
                        }
                        break;
                    }
            }

            if (typeOfGroup == "Students" && numPeople >= 30)
            {
                price *= 0.85;
            }

            if (typeOfGroup == "Business" && numPeople >= 100)
            {
                numPeople -= 10;
            }

            if (typeOfGroup == "Regular" && numPeople >= 10 && numPeople <= 20)
            {
                price *= 0.95;
            }

            total = numPeople * price;

            Console.WriteLine($"Total price: {total:F2}");
        }
    }
}
