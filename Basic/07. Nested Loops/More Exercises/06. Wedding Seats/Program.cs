using System;

namespace _06._Wedding_Seats
{
    class Program
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine());
            int numRows1Sector = int.Parse(Console.ReadLine());
            int numSeatsOddRow = int.Parse(Console.ReadLine());

            int sectorCounter = 0;
            int seatsCounter = 0;

            //Младоженците искат да направят списък кой на кое място ще седи на сватбената церемония.
            //Местата са разделени на различни сектори. 
            //Секторите са главните латински букви като започват от A.
            //Във всеки сектор има определен брой редове.
            //От конзолата се чете броят на редовете в първия сектор(A),
            //като във всеки следващ сектор редовете се увеличават с 1.
            //На всеки ред има определен брой места - тяхната номерация е представена с малките латински букви.
            //Броя на местата на нечетните редове се прочита от конзолата,
            //а на четните редове местата са с 2 повече.

            for (char firstSector = 'A' ; firstSector <= lastSector; firstSector++)
            {
                for (int row = 1; row <= numRows1Sector + sectorCounter; row++)
                {
                    if (row % 2 != 0)
                    {
                        for (int oddSeat = 97; oddSeat < 97 + numSeatsOddRow; oddSeat++)
                        {
                            seatsCounter++;
                            Console.WriteLine($"{firstSector}{row}{(char)oddSeat}");
                        }
                    }
                    else
                    {
                        for (int seat = 97; seat < 97 + numSeatsOddRow + 2; seat++)
                        {
                            seatsCounter++;
                            Console.WriteLine($"{firstSector}{row}{(char)seat}");
                        }
                    }
                }

                sectorCounter++;
            }

            Console.WriteLine(seatsCounter);


        }
    }
}
