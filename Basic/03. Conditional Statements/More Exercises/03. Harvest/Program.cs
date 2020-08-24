using System;

namespace _03._Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int lozeKvMetra = int.Parse(Console.ReadLine());
            double grozdeNaKvMetyr = double.Parse(Console.ReadLine());
            int celLitriVino = int.Parse(Console.ReadLine());
            int broiRabotnici = int.Parse(Console.ReadLine());

            double obshtoGrozde = lozeKvMetra * grozdeNaKvMetyr; // общо изкарано грозде
            double zadelenoGrozde = obshtoGrozde * 0.40; // заделено грозде
            double poluchenoVino = zadelenoGrozde / 2.5;  // получено вино

            if (poluchenoVino < celLitriVino) //  ако е произведено по-малко
            {
                double nedostigVino = Math.Floor(celLitriVino - poluchenoVino); // колко е по-малко, закръглено надолу
                Console.WriteLine($"It will be a tough winter! More {nedostigVino} liters wine needed.");
            }
            else if (poluchenoVino >= celLitriVino)  // ако е произведено точно или повече
            {
                double vinoPovecheObshto = Math.Ceiling(poluchenoVino - celLitriVino); //  колко е повече виното, закръглено нагоре
                double vinoPovecheNaRabotnik = Math.Ceiling(vinoPovecheObshto / broiRabotnici); // колко вино се пада на работник, закръглено нагоре
                poluchenoVino = Math.Floor(poluchenoVino); //  закръглено надолу
                Console.WriteLine($"Good harvest this year! Total wine: {poluchenoVino} liters.");
                Console.WriteLine($"{vinoPovecheObshto} liters left -> {vinoPovecheNaRabotnik} liters per person.");
            }

        }
    }
}
