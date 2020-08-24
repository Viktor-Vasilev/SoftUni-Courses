using System;

namespace _02._Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            double points = double.Parse(Console.ReadLine());
            double bonus = 0;
            if (points <= 100)
            {
                bonus = 5;
            }
            else if (points > 1000)
            {
                bonus = points * 0.10;
            }
            else if (points > 100)
            {
                bonus = points * 0.20;
            }
            if (points % 2 == 0)
            {
                bonus = bonus + 1;
            }
            else if (points % 10 == 5)
            {
                bonus = bonus + 2;
            }
            Console.WriteLine(bonus);
            Console.WriteLine(points + bonus);
        }
    }
}
