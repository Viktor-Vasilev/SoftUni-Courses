using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20200729_Prep___Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // @#+[A-Z][A-Za-z0-9]{4,}[A-Z]@#+

            Regex regex = new Regex(@"^@#+(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+$");

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string barcodeInput = Console.ReadLine();

                Match match = regex.Match(barcodeInput);

                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                string barcode = match.Groups[1].Value;

                StringBuilder group = new StringBuilder();

                for (int j = 0; j < barcode.Length; j++)
                {
                    if (barcode[j] >= 48 && barcode[j]<= 57)
                    {
                        group.Append(barcode[j]);
                    }
                }

                if (String.IsNullOrEmpty(group.ToString()))
                {
                    group.Append("00");
                }

                Console.WriteLine($"Product group: {group}");
            }

            // още две решения по-надолу

            //            1.  using System;
            //            2.  using System.Text.RegularExpressions;
            //            3.  using System.Collections.Generic;
            //            4.
            //5.  namespace Problem_2._Fancy_Barcodes
            //6.	{
            //7.	    class Program
            //8.	    {
            //9.	        static void Main(string[] args)
            //10.	        {
            //11.	            var regex = new Regex(@"^@#+(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+$");
            //12.	            var digitRegex = new Regex(@"\d");
            //13.	 
            //14.	            int n = int.Parse(Console.ReadLine());
            //15.	            for (int i = 0; i<n; i++)
            //16.	            {
            //17.	                string input = Console.ReadLine();
            //18.	                var match = regex.Match(input);
            //19.	                if (match.Success)
            //20.	                {
            //21.	                    string name = match.Groups["barcode"].Value;
            //22.	                    var digitMatch = digitRegex.Matches(name);
            //23.	                    string productGroup = string.Empty;
            //24.	             
            //25.	                    foreach (Match digit in digitMatch)
            //26.	                    {
            //27.	                        if (digit.Success)
            //28.	                        {
            //29.	                            productGroup += digit.Value;
            //30.	                        }
            //31.	                    }
            //32.	                    if (productGroup.Length == 0)
            //33.	                    {
            //34.	                        productGroup = "00";
            //35.	                    }
            //36.	 
            //37.	                    Console.WriteLine($"Product group: {productGroup}");
            //38.	                }
            //39.	                else
            //40.	                {
            //41.	                    Console.WriteLine("Invalid barcode");
            //42.	                }
            //43.	            }
            //44.	        }
            //45.	    }
            //46.	}

            //int n = int.Parse(Console.ReadLine());

            //string pattern = @"([@]#+)(?<word>[A-Z][A-Za-z0-9]{4,}[A-Z])([@]#+)";

            //for (int i = 0; i < n; i++)
            //{
            //    string input = Console.ReadLine();

            //    Regex regex = new Regex(pattern);

            //    Match match = regex.Match(input);

            //    if (match.Success)
            //    {
            //        string barcodeGroup = string.Empty;

            //        string barcode = match.Groups["word"].Value;

            //        for (int j = 0; j < barcode.Length; j++)
            //        {
            //            if ((int)barcode[j] >= 48 && barcode[j] <= 57)
            //            {
            //                barcodeGroup += barcode[j];
            //            }
            //        }

            //        if (String.IsNullOrEmpty(barcodeGroup))
            //        {
            //            barcodeGroup = "00";
            //        }

            //        Console.WriteLine($"Product group: {barcodeGroup}");

            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid barcode");
            //    }
            //}


        }
          
    }

}
