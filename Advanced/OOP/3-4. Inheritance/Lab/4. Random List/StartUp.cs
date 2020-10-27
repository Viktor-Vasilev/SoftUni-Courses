using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList rndList = new RandomList();
            rndList.Add("123");
            rndList.Add("boza");
            rndList.Add("chess");

            string randomString = rndList.RandomString();

            Console.WriteLine(randomString);
        }
    }
}
