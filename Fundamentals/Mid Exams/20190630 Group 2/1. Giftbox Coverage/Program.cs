using System;

namespace _20190630_Group_2_1Giftbox_Coverage
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal sideLength = decimal.Parse(Console.ReadLine());
            long sheetsPaper = long.Parse(Console.ReadLine());
            decimal areaSheetPaper = decimal.Parse(Console.ReadLine());

            decimal smallSheetPaper = 0;
            decimal areaCovered = 0;

            decimal boxArea = sideLength * sideLength * 6;

            for (int i = 1; i <= sheetsPaper; i++)
            {
                if (i % 3 == 0)
                {
                    smallSheetPaper = areaSheetPaper * 0.25m;

                    areaCovered += smallSheetPaper;
                }
                else
                {
                    areaCovered += areaSheetPaper;
                }

            }

            decimal percentage = (areaCovered / boxArea) * 100;

            Console.WriteLine($"You can cover {percentage:f2}% of the box.");



        }
    }
}
