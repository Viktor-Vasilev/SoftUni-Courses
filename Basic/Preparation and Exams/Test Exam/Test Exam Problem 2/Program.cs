using System;

namespace Test_Exam_Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double astrounatHeight = double.Parse(Console.ReadLine());

            double obemRaketa = width * lenght * height;

            double obemStaq = (astrounatHeight + 0.40) * 2 * 2;

            double roomFor = Math.Floor(obemRaketa / obemStaq);

            if (roomFor < 3)
            {
                Console.WriteLine($"The spacecraft is too small.");
            }
            else if (roomFor > 10)
            {
                Console.WriteLine($"The spacecraft is too big.");
            }
            else
            {
                Console.WriteLine($"The spacecraft holds {roomFor} astronauts.");
            }





        }
    }
}
