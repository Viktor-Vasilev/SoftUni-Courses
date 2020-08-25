using System;

namespace Izpit_20190615_6._1_Favorite_Movie
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();

            int limit = 0;

            int recordSum = 0;

            string bestMovie = "";

            while (movieName != "STOP")
            {
                limit++;
                int asciiSum = 0;

                for (int letters = 0; letters < movieName.Length; letters++)
                {
                    char currentLetter = movieName[letters];

                    if (currentLetter >= 97 && currentLetter <= 122)
                    {
                        asciiSum += (currentLetter - 2 * movieName.Length);

                    }
                    else if (currentLetter >= 65 && currentLetter <= 90)
                    {
                        asciiSum += (currentLetter - movieName.Length);
                    }
                    else
                    {
                        asciiSum += currentLetter;
                    }  

                }
               

                if (asciiSum > recordSum)
                {
                    recordSum = asciiSum;
                    bestMovie = movieName;
                }

                if (limit == 7)
                {
                    Console.WriteLine("The limit is reached.");
                    Console.WriteLine($"The best movie for you is {bestMovie} with {recordSum} ASCII sum.");
                    break;
                }

                movieName = Console.ReadLine();

            }

           if (movieName == "STOP")
            {
                Console.WriteLine($"The best movie for you is {bestMovie} with {recordSum} ASCII sum.");
            }

        }
    }
}
