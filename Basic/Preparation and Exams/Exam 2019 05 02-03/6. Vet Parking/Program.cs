using System;

namespace Izpit_20190502_6._Vet_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double totalPay = 0;
            int dayCounter = 0;

            for (int numDay = 1; numDay <= days; numDay++)
            {
                double payPer1Day = 0;

                for (int numHour = 1; numHour <= hours; numHour++)
                {
                    if (numDay % 2 == 0 && numHour % 2 != 0)
                    {
                        payPer1Day += 2.50;
                    }
                    else if (numDay % 2 != 0 && numHour % 2 == 0)
                    {
                        payPer1Day += 1.25;
                    }
                    else
                    {
                        payPer1Day += 1.00;
                    }

                }

                Console.WriteLine($"Day: {numDay} - {payPer1Day:F2} leva");

                totalPay += payPer1Day;
            }
            Console.WriteLine($"Total: {totalPay:F2} leva");




        }
    }
}
