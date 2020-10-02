﻿using System;
using System.IO;

namespace _1._Lab_02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("Input.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
                {
                    int counter = 1;

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        writer.WriteLine($"{counter}. {line}");

                        counter++;
                    }
                }
            }





        }
    }
}
