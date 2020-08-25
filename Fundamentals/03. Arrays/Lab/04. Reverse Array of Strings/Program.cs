using System;

namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] inputStrings = Console.ReadLine()
            //    .Split();

            //Array.Reverse(inputStrings);

            //Console.WriteLine(String.Join(" ", inputStrings));

            string[] strings = Console.ReadLine().Split();

            for (int i = 0; i < strings.Length / 2; i++)
            {
                string temp = strings[i];

                strings[i] = strings[strings.Length - i - 1];

                strings[strings.Length - i - 1] = temp;


            }

            Console.WriteLine(String.Join(" ", strings));




        }
    }
}
