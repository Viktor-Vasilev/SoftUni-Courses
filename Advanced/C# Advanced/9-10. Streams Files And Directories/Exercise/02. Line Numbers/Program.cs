using System;
using System.IO;

namespace _2._Exer_02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var writer = new StreamWriter("../../../ResultText.txt"))
            {
                using (var reader = new StreamReader("text.txt"))
                {
                    int counter = 1;

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();                      

                        int countLetters = 0;
                        int countPunctuations = 0;

                        for (int i = 0; i < line.Length; i++)
                        {
                            if (char.IsPunctuation(line[i]))
                            {
                                countPunctuations++;
                            }
                            else if (char.IsLetter(line[i]))
                            {
                                countLetters++;
                            }
                        }

                        string newLine = $"Line {counter}: {line} ({countLetters})({countPunctuations})";

                        writer.WriteLine(newLine);

                        counter++;
                    }
                }
            }

        }
    }
}
