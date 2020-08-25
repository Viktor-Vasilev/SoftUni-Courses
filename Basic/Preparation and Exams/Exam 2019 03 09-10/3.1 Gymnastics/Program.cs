using System;

namespace Izpit_20190309_3._1_Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            string nation = Console.ReadLine();
            string device = Console.ReadLine();

            double difficulty = 0;
            double performance = 0;

            if (nation == "Russia" && device == "ribbon")
            {
                difficulty = 9.100;
                performance = 9.400;
            }
            if (nation == "Russia" && device == "hoop")
            {
                difficulty = 9.300;
                performance = 9.800;
            }
            if (nation == "Russia" && device == "rope")
            {
                difficulty = 9.600;
                performance = 9.000;
            }
            if (nation == "Bulgaria" && device == "ribbon")
            {
                difficulty = 9.600;
                performance = 9.400;
            }
            if (nation == "Bulgaria" && device == "hoop")
            {
                difficulty = 9.550;
                performance = 9.750;
            }
            if (nation == "Bulgaria" && device == "rope")
            {
                difficulty = 9.500;
                performance = 9.400;
            }
            if (nation == "Italy" && device == "ribbon")
            {
                difficulty = 9.200;
                performance = 9.500;
            }
            if (nation == "Italy" && device == "hoop")
            {
                difficulty = 9.450;
                performance = 9.350;
            }
            if (nation == "Italy" && device == "rope")
            {
                difficulty = 9.700;
                performance = 9.150;
            }

            double total = difficulty + performance;
            double percent = ((20 - total) / 20) * 100;

            Console.WriteLine($"The team of {nation} get {total:F3} on {device}.");

            Console.WriteLine($"{percent:F2}%");

        }
    }
}
