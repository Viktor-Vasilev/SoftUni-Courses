using System;

namespace _07._Flower_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numMagnolii = int.Parse(Console.ReadLine());
            int numZumbuli = int.Parse(Console.ReadLine());
            int numeRozi = int.Parse(Console.ReadLine());
            int numKaktusi = int.Parse(Console.ReadLine());
            double pricePresent = double.Parse(Console.ReadLine());

            double priceMagnolii = 3.25;
            double priceZumbuli = 4.00;
            double priceRozi = 3.50;
            double priceKaktusi = 8.00;

            double Prihod = ((numMagnolii * priceMagnolii) + (numZumbuli * priceZumbuli) + (numeRozi * priceRozi) + (numKaktusi * priceKaktusi)) * 0.95;
            // Console.WriteLine(Prihod);
            if (Prihod >= pricePresent)
            {
                double ostatyk = Math.Floor(Prihod - pricePresent);
                Console.WriteLine($"She is left with {ostatyk} leva.");
            }
            else if (Prihod < pricePresent)
            {
                double nedostig = Math.Ceiling(pricePresent - Prihod);
                Console.WriteLine($"She will have to borrow {nedostig} leva.");
            }

        }
    }
}
