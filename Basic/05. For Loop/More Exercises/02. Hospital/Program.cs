using System;

namespace _02._Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());

            int doctors = 7;

            int untreatedPacients = 0;

            int treatedPacients = 0;

            for (int dayNumber = 1; dayNumber <= days; dayNumber++)
            {
                int numberOfPatients = int.Parse(Console.ReadLine());

                if (dayNumber % 3 == 0)
                {
                    if (untreatedPacients > treatedPacients)
                    {
                        doctors++;
                    }
                }

                if (doctors >= numberOfPatients)
                {
                    treatedPacients += numberOfPatients;
                }
                else
                {
                    treatedPacients += doctors;
                    untreatedPacients += numberOfPatients - doctors;
                }


            }

            Console.WriteLine($"Treated patients: {treatedPacients}.");
            Console.WriteLine($"Untreated patients: {untreatedPacients}.");
        }
    }
}
