using System;

namespace _08._Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double dohod = double.Parse(Console.ReadLine());
            double sredenUspeh = double.Parse(Console.ReadLine());
            double minRZ = double.Parse(Console.ReadLine());
            double scolarshipSocial = 0;
            double scolarshipUspeh = 0;

            if (dohod < minRZ && sredenUspeh > 4.50)
            {
                scolarshipSocial = Math.Floor(minRZ * 0.35);
            }
            if (sredenUspeh >= 5.50)
            {
                scolarshipUspeh = Math.Floor(sredenUspeh * 25);
            }
            if (scolarshipSocial == 0 && scolarshipUspeh == 0)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (scolarshipSocial > scolarshipUspeh)
            {
                Console.WriteLine($"You get a Social scholarship {scolarshipSocial} BGN");
            }
            else if (scolarshipUspeh >= scolarshipSocial)
            {
                Console.WriteLine($"You get a scholarship for excellent results {scolarshipUspeh} BGN");
            }
        }
    }
}
