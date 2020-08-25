using System;

namespace _04._Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int broqch = 1;

            while (broqch <= n)
            {
                Console.WriteLine(broqch);
                broqch = (broqch * 2) + 1;
            }




        }
    }
}
