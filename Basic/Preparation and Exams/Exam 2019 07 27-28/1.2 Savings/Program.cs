using System;

namespace Izpit_20190727_1._2_Savings
{
    class Program
    {
        static void Main(string[] args)
        {
            double incomeForMonth = double.Parse(Console.ReadLine());
            int numMonths = int.Parse(Console.ReadLine());
            double razhodiPerMonth = double.Parse(Console.ReadLine());

            double incomeForMonthRealen = incomeForMonth * 0.70;

            // Console.WriteLine(incomeForMonth);

            double spesteniPari = (incomeForMonthRealen - razhodiPerMonth) * numMonths;
            double PercentSpesteniPari = ((incomeForMonthRealen - razhodiPerMonth) / incomeForMonth) * 100;

            Console.WriteLine($"She can save {PercentSpesteniPari:F2}%");
            Console.WriteLine($"{spesteniPari:F2}");



        }
    }
}
