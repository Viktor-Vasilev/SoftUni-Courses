using System;

namespace _02._Letters_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char begin = char.Parse(Console.ReadLine());
            char finish = char.Parse(Console.ReadLine());
            char bad = char.Parse(Console.ReadLine());

            int counter = 0;

            for (char pos1 = begin; pos1 <= finish; pos1++)
            {
                for (char pos2 = begin; pos2 <= finish; pos2++)
                {
                    for (char pos3 = begin; pos3 <= finish; pos3++)
                    {
                        if (pos1 != bad && pos2 != bad && pos3 != bad)
                        {
                            Console.Write($"{pos1}{pos2}{pos3} ");
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
