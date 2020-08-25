using System;
using System.Linq;

namespace _2._Exer_2.__Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {

            //    string[] input = Console.ReadLine().Split();

            //    int sum = SumValues(input[0], input[1]);

            //    Console.WriteLine(sum);

            //}

            //public static int SumValues(string string1, string string2)
            //{
            //    int sum = 0;

            //    if (string1.Length > string2.Length)
            //    {
            //        for (int i = 0; i < string2.Length; i++)
            //        {
            //            sum += string1[i] * string2[i];
            //        }

            //        for (int i = string2.Length; i < string1.Length; i++)
            //        {
            //            sum += string1[i];
            //        }
            //    }
            //    else if (string1.Length < string2.Length)
            //    {
            //        for (int i = 0; i < string1.Length; i++)
            //        {
            //            sum += string1[i] * string2[i];
            //        }

            //        for (int i = string1.Length; i < string2.Length; i++)
            //        {
            //            sum += string2[i];
            //        }
            //    }
            //    else
            //    {
            //        for (int i = 0; i < string1.Length; i++)
            //        {
            //            sum += string1[i] * string2[i];
            //        }
            //    }

            //    return sum;

            //}

            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            CharMultiplier(input[0], input[1]);

            Console.WriteLine(CharMultiplier(input[0], input[1]));
        }

        static int CharMultiplier(string first, string second)
        {
            int sum = 0;

            string longer = "";
            string shorter = "";

            if (first.Length > second.Length)
            {
                longer = first;
                shorter = second;
            }
            else
            {
                longer = second;
                shorter = first;
            }

            for (int i = 0; i < shorter.Length; i++)
            {
                sum += shorter[i] * longer[i];
            }

            for (int i = shorter.Length; i < longer.Length; i++)
            {
                sum += longer[i];
            }

            return sum;
        }



    }
}

