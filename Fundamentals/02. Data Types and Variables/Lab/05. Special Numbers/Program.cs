using System;

namespace _05._Special_Numbers
{
    class Program
    {
		static void Main(string[] args)
		{
			int number = int.Parse(Console.ReadLine());

			bool isValid = false;

			int digits = 0;
			
			int sum = 0;

			for (int currentNum = 1; currentNum <= number; currentNum++)
			{
				digits = currentNum;

				while (digits != 0)
				{
					sum += (digits % 10);
					digits /= 10;
				}

				if (sum == 5 || sum == 7 || sum == 11)
				{
					isValid = true;
				}

				else
					isValid = false;

				sum = 0;

				Console.WriteLine(currentNum + " -> " + isValid);
			}
		}
    }
}
