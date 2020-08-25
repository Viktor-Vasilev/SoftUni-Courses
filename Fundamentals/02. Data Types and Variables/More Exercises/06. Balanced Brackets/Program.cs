using System;

namespace _06._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int opened = 0;
            int closed = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "(":
                        opened++;
                        if (opened - closed > 1)
                        {
                            Console.WriteLine("UNBALANCED");
                            return;
                        }
                        break;

                    case ")":
                        closed++;
                        if (opened - closed != 0)
                        {
                            Console.WriteLine("UNBALANCED");
                            return;
                        }
                        break;
                }
            }

            if (opened == closed)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }

        }
    }
}
