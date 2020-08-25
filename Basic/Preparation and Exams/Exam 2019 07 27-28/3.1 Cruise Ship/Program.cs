using System;

namespace Izpit_20190727_3._1_Cruise_Ship
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfCruize = Console.ReadLine();
            string typeOfCabin = Console.ReadLine();
            int numberOfNights = int.Parse(Console.ReadLine());

            double priceFor1Night = 0;

            if (typeOfCruize == "Mediterranean")
            {
                if (typeOfCabin == "standard cabin")
                {
                    priceFor1Night = 27.50;
                }
                else if (typeOfCabin == "cabin with balcony")
                {
                    priceFor1Night = 30.20;
                }
                else
                {
                    priceFor1Night = 40.50;
                }
            }
            else if (typeOfCruize == "Adriatic")
            {
                if (typeOfCabin == "standard cabin")
                {
                    priceFor1Night = 22.99;
                }
                else if (typeOfCabin == "cabin with balcony")
                {
                    priceFor1Night = 25.00;
                }
                else
                {
                    priceFor1Night = 34.99;
                }
            }
            else
            {
                if (typeOfCabin == "standard cabin")
                {
                    priceFor1Night = 23.00;
                }
                else if (typeOfCabin == "cabin with balcony")
                {
                    priceFor1Night = 26.60;
                }
                else
                {
                    priceFor1Night = 39.80;
                }
            }

            double total = numberOfNights * priceFor1Night * 4;

            if (numberOfNights > 7)
            {
                total = total * 0.75;
            }

            Console.WriteLine($"Annie's holiday in the {typeOfCruize} sea costs {total:F2} lv.");
            
        }
    }
}
