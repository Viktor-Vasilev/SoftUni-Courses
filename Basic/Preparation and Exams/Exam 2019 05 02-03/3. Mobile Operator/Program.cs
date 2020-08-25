using System;

namespace Izpit_20190502_3._Mobile_Operator
{
    class Program
    {
        static void Main(string[] args)
        {
            string term = Console.ReadLine();
            string type = Console.ReadLine();
            string mobile = Console.ReadLine();
            int months = int.Parse(Console.ReadLine());

            double tax = 0;
            

            if (term == "one")
            {
                if (type == "Small")
                {
                    tax = 9.98;
                }
                else if (type == "Middle")
                {
                    tax = 18.99;
                }
                else if (type == "Large")
                {
                    tax = 25.98;
                }
                else
                {
                    tax = 35.99;
                }
            }
            else
            {
                if (type == "Small")
                {
                    tax = 8.58;
                }
                else if (type == "Middle")
                {
                    tax = 17.09;
                }
                else if (type == "Large")
                {
                    tax = 23.59;
                }
                else
                {
                    tax = 31.79;
                }
            }

            if (tax <= 10 && mobile == "yes")
            {
                tax = tax + 5.50;
            }
            else if ((tax > 10 && tax <= 30) && mobile == "yes")
            {
                tax = tax + 4.35;
            }
            else if (tax > 30 && mobile == "yes")
            {
                tax = tax + 3.85;
            }

            double total = months * tax;

            if (term == "two")
            {
                total = (total * 96.25) / 100;
            }

            Console.WriteLine($"{total:F2} lv.");

        }
    }
}
