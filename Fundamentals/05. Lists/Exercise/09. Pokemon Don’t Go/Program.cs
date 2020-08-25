using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace _2._Exer_09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine().Split().Select(int.Parse).ToList();

            int removedNumber = 0;

            int sum = 0;

            while (pokemons.Count != 0)
            {
                int currentIndex = int.Parse(Console.ReadLine());

                if (currentIndex < 0)
                {
                    removedNumber = pokemons[0];
                    pokemons[0] = pokemons[pokemons.Count - 1];
                }
                else if (currentIndex >= pokemons.Count)
                {
                    removedNumber = pokemons[pokemons.Count - 1];
                    pokemons[pokemons.Count - 1] = pokemons[0];
                }
                else
                {
                    removedNumber = pokemons[currentIndex];
                    pokemons.RemoveAt(currentIndex);
                }

                sum += removedNumber;

                for (int i = 0; i < pokemons.Count; i++)
                {
                    if (pokemons[i] <= removedNumber)
                    {
                        pokemons[i] += removedNumber;
                    }
                    else
                    {
                        pokemons[i] -= removedNumber;
                    }
                }
            }
            Console.WriteLine(sum);





        }
    }
}
