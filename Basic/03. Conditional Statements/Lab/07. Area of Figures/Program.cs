using System;

namespace _07._Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double area = 0;
            if (figure == "square")
            {
                double side = double.Parse(Console.ReadLine());
                area = side * side;
                Console.WriteLine($"{area}");
            }
            else if (figure == "rectangle")
            {
                double side1 = double.Parse(Console.ReadLine());
                double side2 = double.Parse(Console.ReadLine());
                area = side1 * side2;
                Console.WriteLine($"{area}");
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                area = Math.PI * radius * radius;
                Console.WriteLine($"{area}");
            }
            else if (figure == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                area = side * height / 2;
                Console.WriteLine($"{area}");
            }


        }
    }
}
