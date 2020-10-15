using System;

namespace E7Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstTokens = Console.ReadLine().Split();
            string personFullname = $"{firstTokens[0]} {firstTokens[1]}";
            string personAddress = firstTokens[2];
            Tuple<string, string> personInfo = new Tuple<string, string>(personFullname, personAddress);
            

            string[] secondTokens = Console.ReadLine().Split();
            string personName = secondTokens[0];
            int beerLiters = int.Parse(secondTokens[1]);
            Tuple<string, int> personBeer = new Tuple<string, int>(personName, beerLiters);
           

            string[] thirdTokens = Console.ReadLine().Split();
            int intValue = int.Parse(thirdTokens[0]);
            double doubleValue = double.Parse(thirdTokens[1]);
            Tuple<int, double> numbersInfo = new Tuple<int, double>(intValue, doubleValue);

            Console.WriteLine(personInfo);
            Console.WriteLine(personBeer);
            Console.WriteLine(numbersInfo);
        }
    }
}
