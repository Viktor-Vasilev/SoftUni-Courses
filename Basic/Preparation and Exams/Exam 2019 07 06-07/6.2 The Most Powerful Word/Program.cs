using System;

namespace Izpit_20190706_6._2_The_Most_Powerful_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            string bestWord = "";

            double winnerWord = 0;
     
            while (word != "End of words")
            {
                double currentWordSum = 0;

                for (int letters = 0; letters < word.Length; letters++)
                {
                    currentWordSum += word[letters];
                }

                int numLength = word.Length;
                string input2 = word.ToLower();
                if (input2[0] == 'a' || input2[0] == 'e' || input2[0] == 'i' || input2[0] == 'o' || input2[0] == 'u' || input2[0] == 'y')
                {
                    currentWordSum = currentWordSum * numLength;
                }
                else
                {
                    currentWordSum = Math.Floor(currentWordSum / numLength);
                }

                if (currentWordSum > winnerWord)
                {
                    winnerWord = currentWordSum;
                    bestWord = word;
                }

                word = Console.ReadLine();
            }

            if (word == "End of words")
            {
                Console.WriteLine($"The most powerful word is {bestWord} - {winnerWord}");
            }

        }
    }
}
