using System;
using System.Collections.Generic;
using System.Linq;

namespace _20190217_01._Socks
{
    class Program
    {
        static void Main(string[] args)
        {
			int[] leftSocksInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

			int[] rightSocksInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

			Stack<int> leftSocks = new Stack<int>(leftSocksInput);
			Queue<int> rightSocks = new Queue<int>(rightSocksInput);

			Queue<int> madePairs = new Queue<int>();

			while (leftSocks.Count > 0 && rightSocks.Count > 0)
			{
				int currentLeftSock = leftSocks.Pop();
				int currentRightSock = rightSocks.Peek();

				if (currentLeftSock == currentRightSock)
				{
					rightSocks.Dequeue();
					leftSocks.Push(++currentLeftSock);
				}
				else if (currentLeftSock > currentRightSock)
				{
					rightSocks.Dequeue();
					madePairs.Enqueue(currentLeftSock + currentRightSock);
				}
			}

			Console.WriteLine(madePairs.Max());

			Console.WriteLine(string.Join(" ", madePairs));

		}
	}
}
