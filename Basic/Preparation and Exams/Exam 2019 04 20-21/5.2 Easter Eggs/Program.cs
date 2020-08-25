using System;

namespace Izpit_20190420_4._2_Easter_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numEggs = int.Parse(Console.ReadLine());

            int groupRed = 0;
            int groupOrange = 0;
            int groupBlue = 0;
            int groupGreen = 0;

            int currentMax = int.MinValue;
            string colorMax = "";

            for (int i = 1; i <= numEggs; i++)
            {
                string color = Console.ReadLine();

                if (color == "red")
                {
                    groupRed++;
                }
                else if (color == "orange")
                {
                    groupOrange++;
                }
                else if (color == "blue")
                {
                    groupBlue++;
                }
                else
                {
                    groupGreen++;
                }

            }

            if (groupRed >= currentMax)
            {
                currentMax = groupRed;
                colorMax = "red";
            }
            if (groupOrange >= currentMax)
            {
                currentMax = groupOrange;
                colorMax = "orange";
            }
            if (groupBlue >= currentMax)
            {
                currentMax = groupBlue;
                colorMax = "blue";
            }
            if (groupGreen >= currentMax)
            {
                currentMax = groupGreen;
                colorMax = "green";
            }

            Console.WriteLine($"Red eggs: {groupRed}");
            Console.WriteLine($"Orange eggs: {groupOrange}");
            Console.WriteLine($"Blue eggs: {groupBlue}");
            Console.WriteLine($"Green eggs: {groupGreen}");
            Console.WriteLine($"Max eggs: {currentMax} -> {colorMax}");

        }
    }
}
