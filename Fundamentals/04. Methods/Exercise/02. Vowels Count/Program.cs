using System;

namespace _2.Ex_02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();


            CountVowels(text);


        }

        static void CountVowels(string text)
        {
            int vowelsCounter = 0;

            for (int i = 0; i < text.Length ; i++)
            {
               if (text[i] == 'a' || text[i] == 'i' || text[i] == 'u' || text[i] == 'o' || text[i] == 'e')
                {
                    vowelsCounter++;
                }

            }

            Console.WriteLine(vowelsCounter);



        }


    }
}
