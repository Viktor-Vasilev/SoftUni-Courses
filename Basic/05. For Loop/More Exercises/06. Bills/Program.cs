using System;

namespace _06._Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());

            int billWater = 0;
            int billInternet = 0;
            double billElectricity = 0;
            double billOthersForCurrentMonth = 0;
            double billOthers = 0;

            for (int i = 1; i <= months; i++)
            {
                double billElectricityCurrentMonth = double.Parse(Console.ReadLine());
                billWater += 20;
                billInternet += 15;
                billElectricity += billElectricityCurrentMonth;
                billOthersForCurrentMonth = (20 + 15 + billElectricityCurrentMonth) * 1.20;
                billOthers += billOthersForCurrentMonth;
            }

            double average = (billElectricity + billWater + billInternet + billOthers) / months;

            Console.WriteLine($"Electricity: {billElectricity:F2} lv");
            Console.WriteLine($"Water: {billWater:F2} lv");
            Console.WriteLine($"Internet: {billInternet:F2} lv");
            Console.WriteLine($"Other: {billOthers:F2} lv");
            Console.WriteLine($"Average: {average:F2} lv");
        }
    }
}
