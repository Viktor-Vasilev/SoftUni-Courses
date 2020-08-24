using System;

namespace _01._Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int seconds1 = int.Parse(Console.ReadLine());
            int seconds2 = int.Parse(Console.ReadLine());
            int seconds3 = int.Parse(Console.ReadLine());
            int secondsAll = seconds1 + seconds2 + seconds3;
            int minutes = secondsAll / 60;
            int seconds = secondsAll % 60;
            if (seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
        }
    }
}
