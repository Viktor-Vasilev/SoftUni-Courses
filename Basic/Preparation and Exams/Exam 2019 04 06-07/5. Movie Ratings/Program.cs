using System;

namespace Izpit_20190406_5._Movie_Ratings
{
    class Program
    {
        static void Main(string[] args)
        {
            int numMovies = int.Parse(Console.ReadLine());

            double currentMin = double.MaxValue;
            double currentMax = double.MinValue;
            double sumRatingMovie = 0;
            string movieNameMaxRating = "";
            string movienameMinRating = "";

            for (int i = 1; i <= numMovies; i++)
            {
                string nameMovie = Console.ReadLine();
                double ratingMovie = double.Parse(Console.ReadLine());

                if (ratingMovie > currentMax)
                {
                    currentMax = ratingMovie;
                    movieNameMaxRating = nameMovie;
                }
                if (ratingMovie < currentMin)
                {
                    currentMin = ratingMovie;
                    movienameMinRating = nameMovie;
                }
                
                sumRatingMovie += ratingMovie;

            }

            double averageRating = sumRatingMovie / numMovies;

            Console.WriteLine($"{movieNameMaxRating} is with highest rating: {currentMax:F1}");
            Console.WriteLine($"{movienameMinRating} is with lowest rating: {currentMin:F1}");
            Console.WriteLine($"Average rating: {averageRating:F1}");

        }
    }
}
