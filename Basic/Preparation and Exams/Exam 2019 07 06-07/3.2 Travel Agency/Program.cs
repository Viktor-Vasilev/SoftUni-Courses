using System;

namespace Izpit_20190706_3._2_Travel_Agency
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            string package = Console.ReadLine();
            string VIP = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            double priceFor1Day = 0;


            if (town == "Bansko" || town == "Borovets")
            {
                if (package == "withEquipment" && VIP == "no")
                {
                    priceFor1Day = 100;
                }
                else if (package == "withEquipment" && VIP == "yes")
                {
                    priceFor1Day = 100 * 0.90;
                }
                else if (package == "noEquipment" && VIP == "no")
                {
                    priceFor1Day = 80;
                }
                else if (package == "noEquipment" && VIP == "yes")
                {
                    priceFor1Day = 80 * 0.95;
                }
            }
            else if (town == "Varna" || town == "Burgas")
            {
                if (package == "noBreakfast" && VIP == "no")
                {
                    priceFor1Day = 100;
                }
                else if (package == "noBreakfast" && VIP == "yes")
                {
                    priceFor1Day = 100 * 0.93;
                }
                else if (package == "withBreakfast" && VIP == "no")
                {
                    priceFor1Day = 130;
                }
                else if (package == "withBreakfast" && VIP == "yes")
                {
                    priceFor1Day = 130 * 0.88;
                }
            }

            if (days > 7)
            {
                days = days - 1;
            }

            

            
            if (days >= 1 && (town == "Bansko" || town == "Borovets" || town == "Varna" || town == "Burgas") && (package == "noEquipment" || package == "withEquipment" || package == "noBreakfast" || package == "withBreakfast"))
            {
                double total = days * priceFor1Day;
                Console.WriteLine($"The price is {total:F2}lv! Have a nice time!");
            }

            else if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
            }

            else 
            {               
                Console.WriteLine("Invalid input!");
            }
            

        }

            

        
    }
}
