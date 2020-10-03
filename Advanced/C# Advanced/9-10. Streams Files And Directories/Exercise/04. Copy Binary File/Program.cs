using System;
using System.IO;

namespace _2._Exer_04._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream source = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (FileStream destination = new FileStream("../../../newCopy.png", FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[1];

                        int bytesCount = source.Read(buffer, 0, buffer.Length);

                        if (bytesCount == 0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, bytesCount);
                    }
                }
            }

        }
    }
}
