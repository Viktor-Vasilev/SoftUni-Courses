using System;

namespace _07._Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            double metri = double.Parse(Console.ReadLine());
            double price = 7.61;
            double discount = price * 0.18 * metri;
            double suma = (metri * price) - discount;
            Console.WriteLine($"The final price is: {suma:f2} lv.");
            Console.WriteLine($"The discount is: {discount:f2} lv.");
        }
    }
}
