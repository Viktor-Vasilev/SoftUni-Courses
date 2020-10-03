using System;
using System.IO;
using System.IO.Compression;

namespace _2._Exer_06._Zip_And_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string startPath = "../../../Images";
            string zipPath = "../../../Zipped/zippedFile.zip";
            string extractPath = "../../../Unzipped";

            ZipFile.CreateFromDirectory(startPath, zipPath);
            ZipFile.ExtractToDirectory(zipPath, extractPath);


        }
    }
}
