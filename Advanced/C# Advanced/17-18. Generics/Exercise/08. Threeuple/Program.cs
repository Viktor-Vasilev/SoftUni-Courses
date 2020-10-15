using System;

namespace E8Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Threeuple<string, string, string> threeuple1 = new Threeuple<string, string, string>(input[0] + " " + input[1], input[2], input[3]);


            string[] input2 = Console.ReadLine().Split();
            bool isDrunk = false;
            string drunk = input2[2];
            if (drunk == "drunk")
            {
                isDrunk = true;
            }
            // bool isDrunk = input[2] == "drunk" ? true : false;
            Threeuple<string, int, bool> threeuple2 = new Threeuple<string, int, bool>(input2[0], int.Parse(input2[1]), isDrunk);


            string[] input3 = Console.ReadLine().Split();
            Threeuple<string, double, string> threeuple3 = new Threeuple<string, double, string>(input3[0], double.Parse(input3[1]), input3[2]);


            Console.WriteLine(threeuple1);
            Console.WriteLine(threeuple2);
            Console.WriteLine(threeuple3);

            //string[] personInfo = Console.ReadLine().Split();
            //string fullName = personInfo[0] + " " + personInfo[1];
            //string neighborhood = personInfo[2];
            //string town = personInfo[3];

            //string[] beerInfo = Console.ReadLine().Split();
            //string name = beerInfo[0];
            //int liters = int.Parse(beerInfo[1]);
            //bool isDrunk = beerInfo[2] == "drunk" ? true : false;

            //string[] sashoInfo = Console.ReadLine().Split();
            //string sashoName = sashoInfo[0];
            //double sashoDouble = double.Parse(sashoInfo[1]);
            //string sashoBanka = sashoInfo[2];

            //Threeuple<string, string, string> personTuple = new Threeuple<string, string, string>(fullName, neighborhood, town);
            //Threeuple<string, int, bool> beerTuple = new Threeuple<string, int, bool>(name, liters, isDrunk);
            //Threeuple<string, double, string> specialTuple = new Threeuple<string, double, string>(sashoName, sashoDouble, sashoBanka);

            //Console.WriteLine(personTuple);
            //Console.WriteLine(beerTuple);
            //Console.WriteLine(specialTuple);

        }
    }
}
