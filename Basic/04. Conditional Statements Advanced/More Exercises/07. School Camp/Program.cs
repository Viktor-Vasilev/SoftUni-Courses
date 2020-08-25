using System;

namespace _07._School_Camp
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string typeOfGroup = Console.ReadLine();
            int numOfStudents = int.Parse(Console.ReadLine());
            int numOfNights = int.Parse(Console.ReadLine());

            string typeOfSport = "";
            double priceFor1PersonBoysOrGirls = 0;
            double priceFor1PersonMixed = 0;
            double total = 0;

            if (season == "Winter")
            {
                if (typeOfGroup == "boys" || typeOfGroup == "girls")
                {
                    priceFor1PersonBoysOrGirls = 9.60;
                    total = numOfStudents * numOfNights * priceFor1PersonBoysOrGirls;
                }
                else
                {
                    priceFor1PersonMixed = 10.00;
                    total = numOfStudents * numOfNights * priceFor1PersonMixed;
                }
            }
            else if (season == "Spring")
            {
                if (typeOfGroup == "boys" || typeOfGroup == "girls")
                {
                    priceFor1PersonBoysOrGirls = 7.20;
                    total = numOfStudents * numOfNights * priceFor1PersonBoysOrGirls;
                }
                else
                {
                    priceFor1PersonMixed = 9.50;
                    total = numOfStudents * numOfNights * priceFor1PersonMixed;
                }
            }
            else
            {
                if (typeOfGroup == "boys" || typeOfGroup == "girls")
                {
                    priceFor1PersonBoysOrGirls = 15.00;
                    total = numOfStudents * numOfNights * priceFor1PersonBoysOrGirls;
                }
                else
                {
                    priceFor1PersonMixed = 20.00;
                    total = numOfStudents * numOfNights * priceFor1PersonMixed;
                }
            }

            if (numOfStudents >= 50)
            {
                total = total * 0.50;
            }
            if (numOfStudents >= 20 && numOfStudents < 50)
            {
                total = total * 0.85;
            }
            if (numOfStudents >= 10 && numOfStudents < 20)
            {
                total = total * 0.95;
            }

            if (season == "Winter" && typeOfGroup == "girls")
            {
                typeOfSport = "Gymnastics";
            }
            if (season == "Spring" && typeOfGroup == "girls")
            {
                typeOfSport = "Athletics";
            }
            if (season == "Summer" && typeOfGroup == "girls")
            {
                typeOfSport = "Volleyball";
            }
            if (season == "Winter" && typeOfGroup == "boys")
            {
                typeOfSport = "Judo";
            }
            if (season == "Spring" && typeOfGroup == "boys")
            {
                typeOfSport = "Tennis";
            }
            if (season == "Summer" && typeOfGroup == "boys")
            {
                typeOfSport = "Football";
            }
            if (season == "Winter" && typeOfGroup == "mixed")
            {
                typeOfSport = "Ski";
            }
            if (season == "Spring" && typeOfGroup == "mixed")
            {
                typeOfSport = "Cycling";
            }
            if (season == "Summer" && typeOfGroup == "mixed")
            {
                typeOfSport = "Swimming";
            }

            Console.WriteLine($"{typeOfSport} {total:F2} lv.");
        }
    }
}
