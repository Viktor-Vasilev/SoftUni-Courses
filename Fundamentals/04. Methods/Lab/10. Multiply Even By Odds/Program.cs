using System;

namespace _10._Multiply_Even_By_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            n = Math.Abs(n);

            Console.WriteLine(MultiplyEvenByOdds(n)); 


        }

        static int MultiplyEvenByOdds(int n)
        {
            return CalculateOddSum(n) * CalculateEvenSum(n);
        }

        static int CalculateOddSum(int n)
        {
            string number = n.ToString();
            int sum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                
                int currentDiggit = int.Parse(number[i].ToString());
                if (currentDiggit % 2 == 1)
                {
                    sum += currentDiggit;
                }

            }
            
            return sum;
           
        }

        static int CalculateEvenSum(int n)
        {
            string number = n.ToString();
            int sum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                int currentDiggit = int.Parse(number[i].ToString());
                if (currentDiggit % 2 == 0)
                {
                    sum += currentDiggit;
                }

            }

            return sum;

        }
    }
}
