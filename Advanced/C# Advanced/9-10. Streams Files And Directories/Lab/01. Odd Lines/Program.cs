using System;
using System.IO;

namespace _1._Lab_01._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("Input.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
                {
                    int counter = 0;

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (counter % 2 == 0)
                        {
                            writer.WriteLine(line);
                        }

                        counter++;
                    }
                }
            }

            




        }
    }
}
