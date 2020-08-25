using System;

namespace _04._Car_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int begin = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());

//Ако номерът започва с четна цифра, то той трябва да завършва на нечетна цифра и обратното
//– ако започва с нечетна, завършва на четна
//Първата цифра от номера е по-голяма от последната
//Сумата от втората и третата цифра трябва да е четно число


            for (int pos1 = begin; pos1 <= finish; pos1++)
            {
                for (int pos2 = begin; pos2 <= finish; pos2++)
                {
                    for (int pos3 = begin; pos3 <= finish; pos3++)
                    {
                        for (int pos4 = begin; pos4 <= finish; pos4++)
                        {
                            if (pos1 % 2 == 0 && pos4 % 2 != 0 || pos1 % 2 != 0 && pos4 % 2 == 0)
                            {
                                if ((pos2 + pos3) % 2 == 0 && pos1 > pos4)
                                {
                                    Console.Write($"{pos1}{pos2}{pos3}{pos4} ");
                                }
                            }   
                        }
                    }
                }
            }
        }
    }
}
