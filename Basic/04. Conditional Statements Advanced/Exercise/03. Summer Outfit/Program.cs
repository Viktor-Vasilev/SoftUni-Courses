using System;

namespace _03._Summer_Outfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int graduses = int.Parse(Console.ReadLine());
            string partOfDay = Console.ReadLine();

            string outfit = "";
            string shoes = "";

            if ((partOfDay == "Morning") && (graduses >= 10 && graduses <= 18))
            {
                outfit = "Sweatshirt";
                shoes = "Sneakers";
            }
            else if ((partOfDay == "Afternoon") && (graduses >= 10 && graduses <= 18))
            {
                outfit = "Shirt";
                shoes = "Moccasins";
            }
            else if ((partOfDay == "Evening") && (graduses >= 10 && graduses <= 18))
            {
                outfit = "Shirt";
                shoes = "Moccasins";
            }
            else if ((partOfDay == "Morning") && (graduses > 18 && graduses <= 24))
            {
                outfit = "Shirt";
                shoes = "Moccasins";
            }
            else if ((partOfDay == "Afternoon") && (graduses > 18 && graduses <= 24))
            {
                outfit = "T-Shirt";
                shoes = "Sandals";
            }
            else if ((partOfDay == "Evening") && (graduses > 18 && graduses <= 24))
            {
                outfit = "Shirt";
                shoes = "Moccasins";
            }
            else if (partOfDay == "Morning" && graduses >= 25)
            {
                outfit = "T-Shirt";
                shoes = "Sandals";
            }
            else if (partOfDay == "Afternoon" && graduses >= 25)
            {
                outfit = "Swim Suit";
                shoes = "Barefoot";
            }
            else if (partOfDay == "Evening" && graduses >= 25)
            {
                outfit = "Shirt";
                shoes = "Moccasins";
            }
            Console.WriteLine($"It's {graduses} degrees, get your {outfit} and {shoes}.");
        }
    }
}
