using System;

namespace _09._On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arriveHour = int.Parse(Console.ReadLine());
            int arriveMinutes = int.Parse(Console.ReadLine());

            int exam = (examHour * 60) + examMinutes;
            int arrive = (arriveHour * 60) + arriveMinutes;

            if (exam == arrive)
            {
                Console.WriteLine("On time");
            }
            else if (exam < arrive)
            {
                if ((arrive - exam) < 60)
                {
                    int minutesLate1 = arrive - exam;
                    Console.WriteLine("Late");
                    Console.WriteLine($"{minutesLate1} minutes after the start");
                }
                else
                {
                    int hoursLate = (arrive - exam) / 60;
                    int minutesLate2 = (arrive - exam) % 60;
                    Console.WriteLine("Late");
                    Console.WriteLine($"{hoursLate}:{minutesLate2:D2} hours after the start");
                }
            }
            else if (exam > arrive)
            {
                if ((exam - arrive) <= 30)
                {
                    int minutesEarly0 = exam - arrive;
                    Console.WriteLine("On time");
                    Console.WriteLine($"{minutesEarly0} minutes before the start");
                }
                else if ((exam - arrive) < 60)
                {
                    int minutesEarly1 = exam - arrive;
                    Console.WriteLine("Early");
                    Console.WriteLine($"{minutesEarly1:D2} minutes before the start");
                }
                else
                {
                    int hoursEarly = (exam - arrive) / 60;
                    int minutesEarly2 = (exam - arrive) % 60;
                    Console.WriteLine("Early");
                    Console.WriteLine($"{hoursEarly}:{minutesEarly2:D2} hours before the start");
                }
            }
        }
    }
}
