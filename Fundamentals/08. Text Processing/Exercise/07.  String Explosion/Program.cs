using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _2._Exer_7._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();

            //int bombPower = 0;

            //for (int i = 0; i < input.Length - 1; i++)
            //{
            //    if (input[i] == '>')
            //    {
            //        bombPower += input[i + 1] - '0';

            //        while (i + 1 < input.Length && input[i + 1] != '>' && bombPower > 0)
            //        {
            //            input = input.Remove(i + 1, 1);
            //            bombPower--;
            //        }
            //    }
            //}

            //Console.WriteLine(input);

            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            int power = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];

                if (current == '>')
                {
                    power += int.Parse(input[i + 1].ToString());
                    sb.Append(current);
                }
                else if (power == 0)
                {
                    sb.Append(current);
                }
                else
                {
                    power--;
                }
            }

            Console.WriteLine(sb);

        }
    }
}
