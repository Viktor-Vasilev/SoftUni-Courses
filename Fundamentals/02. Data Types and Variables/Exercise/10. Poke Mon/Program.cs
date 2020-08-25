using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int currentPokePower = pokePower;
            int poked = 0;

            while (currentPokePower >= distance)
            {
                currentPokePower -= distance;

                poked++;

                if (currentPokePower == pokePower * 0.5 && exhaustionFactor != 0)
                {
                    currentPokePower /= exhaustionFactor;
                }
            }

            Console.WriteLine(currentPokePower);
            Console.WriteLine(poked);

        }
    }
}
