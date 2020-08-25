using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int headsetCounter = 0;
            int mouseCounert = 0;
            int keyboardCounter = 0;
            int displayCounter = 0;

            for (int game = 1; game <= lostGames; game++)
            {
                if (game % 2 == 0)
                {
                    headsetCounter++;
                }
                if (game % 3 == 0)
                {
                    mouseCounert++;
                }
                if (game % 6  == 0)
                {
                    keyboardCounter++;
                }
                if (game % 12 == 0)
                {
                    displayCounter++;
                }
            }

            double expenses = (headsetCounter * headsetPrice) + (mouseCounert * mousePrice) + (keyboardCounter * keyboardPrice) + (displayCounter * displayPrice);

            Console.WriteLine($"Rage expenses: {expenses:F2} lv.");

            }
    }

    // решение с булеви, което е ДВА ПЪТИ по-бързо!!!!!!!
    //namespace P10_RageExpenses
    //{
    //    using System;

    //    class P10_RageExpenses
    //    {
    //        static void Main(string[] args)
    //        {
    //            int lostGames = int.Parse(Console.ReadLine());
    //            double headsetPrice = double.Parse(Console.ReadLine());
    //            double mousePrice = double.Parse(Console.ReadLine());
    //            double keyboardPrice = double.Parse(Console.ReadLine());
    //            double displayPrice = double.Parse(Console.ReadLine());

    //            int headsetCount = 0;
    //            int mouseCount = 0;
    //            int keyboardCount = 0;
    //            int displayCount = 0;

    //            for (int i = 1; i <= lostGames; i++)
    //            {
    //                bool isHeadsetTrashed = false;
    //                bool isMouseTrashed = false;
    //                if (i % 2 == 0)
    //                {
    //                    isHeadsetTrashed = true;
    //                    headsetCount++;
    //                }

    //                if (i % 3 == 0)
    //                {
    //                    isMouseTrashed = true;
    //                    mouseCount++;
    //                }

    //                if (isHeadsetTrashed && isMouseTrashed)
    //                {
    //                    keyboardCount++;
    //                    if (keyboardCount % 2 == 0)
    //                    {
    //                        displayCount++;
    //                    }
    //                }
    //            }

    //            double expenses = (headsetCount * headsetPrice) + (mouseCount * mousePrice) + (keyboardCount * keyboardPrice) + (displayCount * displayPrice);
    //            Console.WriteLine($"Rage expenses: {expenses:F2} lv.");
    //        }
    //    }
    //}
}
