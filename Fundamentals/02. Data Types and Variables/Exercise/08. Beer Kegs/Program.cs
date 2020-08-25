using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfKegs = int.Parse(Console.ReadLine());

            string bestKeg = "";

            double maxVolume = double.MinValue;

            while (numOfKegs > 0)
            {
                string kegName = Console.ReadLine();
                double currentKegRadius = double.Parse(Console.ReadLine());
                int currentKegHeight = int.Parse(Console.ReadLine());

                double currentKegVolume = Math.PI * currentKegRadius * currentKegRadius * currentKegHeight;

                if (currentKegVolume >= maxVolume)
                {
                    maxVolume = currentKegVolume;
                    bestKeg = kegName;
                }

                numOfKegs--;
            }

            Console.WriteLine($"{bestKeg}");
        }
    }
}
