using System;
using System.Collections.Generic;
using System.IO;

namespace _2._Exer_01._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] charsToReplace = new char[] { '-', ',', '.', '!', '?' };

            int counter = 0;

            using (var reader = new StreamReader("text.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();                

                    if (counter % 2 == 0)
                    {
                        List<string> resultText = new List<string>();

                        string[] lineArray = line.Split(' ');

                        for (int i = lineArray.Length - 1; i >= 0; i--)
                        {
                            resultText.Add(lineArray[i]);
                        }

                        string resultString = string.Join(" ", resultText);

                        foreach (var item in charsToReplace)
                        {
                            resultString = resultString.Replace(item, '@');
                        }

                        Console.WriteLine(resultString);
                    }

                    counter++;
                }
            }
        }
    }
}
