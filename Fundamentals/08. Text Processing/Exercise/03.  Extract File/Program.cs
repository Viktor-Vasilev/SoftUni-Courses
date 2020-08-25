using System;
using System.Linq;

namespace _2._Exer_3.__Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {

            //string path = Console.ReadLine();

            //string file = path.Substring(path.LastIndexOf('\\') + 1);

            //string fileExtension = file.Substring(file.IndexOf('.') + 1);

            //string fileName = file.Substring(0, file.Length - fileExtension.Length - 1);

            //Console.WriteLine($"File name: {fileName}");
            //Console.WriteLine($"File extension: {fileExtension}");

            var input = Console.ReadLine().Split('\\', StringSplitOptions.RemoveEmptyEntries);

            var file = input[input.Length - 1].Split('.');

            Console.WriteLine($"File name: {file[0]}");
            Console.WriteLine($"File extension: {file[1]}");

        }
    }
}
