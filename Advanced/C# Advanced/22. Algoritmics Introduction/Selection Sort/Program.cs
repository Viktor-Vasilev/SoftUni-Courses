using System;

namespace Selection_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 4, 2, 1, 5 };
            SelectionSort(arr);

            Console.WriteLine(String.Join(" ", arr));
        }

        public static void SelectionSort(int[] arr)
        {
            int minIndex;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = temp;
            }
        }

    }
}
