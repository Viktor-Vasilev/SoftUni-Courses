using System;

namespace _2._Exer_01._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new string[] { "Excellent product.", "Such a great product.", "I always use that product.",
                                              "Best product of its category.", "Exceptional product.", "I can’t live without this product." };

            string[] events = new string[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                                             "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };

            string[] authors = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int number = int.Parse(Console.ReadLine());
            string message = " ";

            while (number > 0)
            {
                message += GetRandomMessage(phrases) + " ";
                message += GetRandomMessage(events) + " ";
                message += GetRandomMessage(authors) + " ";
                message += GetRandomMessage(cities) + " ";

                Console.WriteLine(message);
                message = " ";

                number--;
            }

        }

        public static string GetRandomMessage(string[] data)
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, data.Length - 1);
            return data[randomIndex];
        }
    }
}
