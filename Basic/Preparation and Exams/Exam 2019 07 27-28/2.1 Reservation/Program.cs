using System;

namespace Izpit_20190727_2._1_Reservation
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayOfReservation = int.Parse(Console.ReadLine()); 
            int monthOfReservation = int.Parse(Console.ReadLine());
            int dayOfAccomodation = int.Parse(Console.ReadLine());
            int monthOfAccomodation = int.Parse(Console.ReadLine());
            int dayOfLeaving = int.Parse(Console.ReadLine());
            int monthOfLeaving = int.Parse(Console.ReadLine());

            double priceNight = 30.00;

            double numNights = dayOfLeaving - dayOfAccomodation;

            double difference = dayOfAccomodation - dayOfReservation;

            if (monthOfReservation < monthOfAccomodation)
            {
                priceNight = 25.00 * 0.80;
            }

            if (monthOfReservation == monthOfAccomodation && difference >= 10)
            {
                priceNight = 25.00;
            }

            double total = priceNight * numNights;

            Console.WriteLine($"Your stay from {dayOfAccomodation}/{monthOfAccomodation} to {dayOfLeaving}/{monthOfLeaving} will cost {total:F2}");




             




        }
    }
}
