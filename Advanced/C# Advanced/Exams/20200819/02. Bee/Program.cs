using System;

namespace _20200819_02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] beeTeritory = new char[n,n];

            int beeRow = -1;
            int beeCol = -1;

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    beeTeritory[row, col] = input[col];

                    if (input[col] == 'B')
                    {   beeRow = row;
                        beeCol = col;
                    }
                }                

            }
            int polinatedFlowers = 0;

            string command = Console.ReadLine();

            while (command != "End")
            {
                beeTeritory[beeRow, beeCol] = '.'; // маркираме сегашното ни местоположение с .
                
                if (command == "up")  // местим пчелата
                {
                    beeRow--;
                }
                else if (command == "down")
                {
                    beeRow++;
                }
                else if (command == "left")
                {
                    beeCol--;
                }
                else if (command == "right")
                {
                    beeCol++;
                }


                if (beeCol > n -1 || beeCol < 0 || beeRow < 0 || beeRow > n -1) // проверяваме дали не сме излезли
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (beeTeritory[beeRow, beeCol] == 'f') // ако срещнем цвете
                {
                    polinatedFlowers++;
                }
                else if (beeTeritory[beeRow, beeCol] == 'O') // ако срещнем бонус
                {
                    continue;
                }


                command = Console.ReadLine();
            }

            if (command == "End") // казваме къде е пчелата!!!!!!!
            {
                beeTeritory[beeRow, beeCol] = 'B'; 
            }

            if (polinatedFlowers < 5) // проверяваме дали е успешна
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinatedFlowers} flowers!");
            }

            

            for (int row = 0; row < n; row++) // отпечатваме
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(beeTeritory[row, col]);
                }
                Console.WriteLine();
            }

        }
    }
}
