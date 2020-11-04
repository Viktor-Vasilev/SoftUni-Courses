using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();


            foreach (string number in phoneNumbers)
            {
                if (!number.All(char.IsDigit)) // проверяваме дали всички са числа
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }
                
              

                if (number.Length == 10)
                {
                    smartphone.Call(number);
                }
                else
                {
                    stationaryPhone.Call(number);
                }

               
            }

            string[] urls = Console.ReadLine().Split();

            foreach (string url in urls)
            {
                if (url.Any(char.IsDigit)) // проверяваме дали няма цифра
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }             

                smartphone.Browse(url);

            }


        }
    }
}
