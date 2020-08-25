using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;

namespace _2._Exer_05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            //int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //int bombNum = command[0];
            //int bombPower = command[1];

            //for (int i = 0; i < bombPower; i++)
            //{

            //    for (int j = 0; j < input.Count; j++)
            //    {
            //        if (input[j] == bombNum)
            //        {
            //            if (j - 1 >= 0)
            //            {
            //                input.RemoveAt(j - 1);
            //                j--;
            //            }

            //            if (j + 1 < input.Count)
            //            {
            //                input.RemoveAt(j + 1);
            //            }

            //        }
            //    }
            //}

            //input.RemoveAll(n => n == bombNum);

            //int sum = 0;

            //for (int i = 0; i < input.Count; i++)
            //{
            //    sum += input[i];
            //}

            //Console.WriteLine(sum);

            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int specialBombNumber = bombData[0];
            int power = bombData[1];

            int bombIndex = list.IndexOf(specialBombNumber); // взимаме индекса на бомбата

            while (bombIndex != -1)
            {
                int leftNumbers = bombIndex - power;  // взимаме рейнджа отляво 
                int rightNumbers = bombIndex + power; // взимаме рейджа отдясно

                if (leftNumbers < 0) // проверяваме дали не сме извън масива отляво, тоест ако сме се върнали преди началото на масива да се върнем в неговото начало.
                {
                    leftNumbers = 0;
                }
                if (rightNumbers > list.Count -1) // проверяваме дали не сме извън масива отдясно
                {
                    rightNumbers = list.Count - 1;
                }

                list.RemoveRange(leftNumbers, rightNumbers - leftNumbers + 1); // изтриваме рейнджа

                bombIndex = list.IndexOf(specialBombNumber);
            }

            //int sum = 0;

            //foreach (var item in list)
            //{
            //    sum += item;
            //}
           // Console.WriteLine(sum);

            Console.WriteLine(list.Sum());
        }
    }
}
