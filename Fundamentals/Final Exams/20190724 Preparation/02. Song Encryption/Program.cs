using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20190724_Preparation_02_Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            // с методи
            
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] splitted = input.Split(":");

                string artist = splitted[0];
                string song = splitted[1];
                // or
                //string artist = input.Substring(0, input.IndexOf(":"))
                //string song = input.Substring(input.IndexOf(":") + 1);

                if (ValidateArtist(artist) && ValidateSong(song))
                {
                    int length = artist.Length;

                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == ':')
                        {
                            sb.Append('@');
                        }                       
                        else if (input[i] == ' ' || input[i] == '\'')
                        {
                            sb.Append(input[i]);
                        }
                        else
                        {
                            char symbol = (char)(input[i] + length);

                            if (char.IsUpper(input[i]) && symbol > 'Z')
                            {
                                symbol = (char)(symbol - 26);
                            }
                            else if (char.IsLower(input[i]) && symbol > 'z')
                            {
                                symbol = (char)(symbol - 26);
                            }

                            sb.Append(symbol);
                        }

                    }

                    Console.WriteLine($"Successful encryption: {sb.ToString()}");

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }


                input = Console.ReadLine();
            }


        }

        public static bool ValidateSong(string song)
        {
            bool isValid = true;

            for (int i = 0; i < song.Length; i++)
            {
                if (!char.IsUpper(song[i]) && song[i] != ' ')
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }



        public static bool ValidateArtist(string artist)
        {
            bool isValid = true;

            if (!char.IsUpper(artist[0]))
            {
                isValid = false;
            }

            for (int i = 1; i < artist.Length; i++)
            {
                if (!char.IsLower(artist[i]) && artist[i] != '\'' && artist[i] != ' ')
                {
                    isValid = false;
                    break;
                }
            }


            return isValid;
        }

        // с регекс

        //string input = "";
        //Regex regex = new Regex(@"^([A-Z][a-z\' ]+)\:[A-Z]+(\s?[A-Z]+)*\b");
        //while ((input = Console.ReadLine()) != "end")
        //{
        //    if (regex.IsMatch(input))
        //    {
        //        string[] splitInput = input.Split(":");
        //        string artist = splitInput[0];
        //        string encript = string.Empty;

        //        char[] arrInput = input.ToCharArray();
        //        for (int i = 0; i < arrInput.Length; i++)
        //        {
        //            int key = artist.Length;
        //            char newSymbol = arrInput[i];
        //            if (arrInput[i] != ' ' && arrInput[i] != '\'')
        //            {
        //                if (char.IsLetter(arrInput[i]) && char.IsLower(arrInput[i]))
        //                {
        //                    int symbol = arrInput[i];
        //                    while (key > 0)
        //                    {
        //                        symbol++;
        //                        key--;
        //                        if (symbol == 123)
        //                        {
        //                            symbol = 97;
        //                        }

        //                    } //counter
        //                    newSymbol = (char)symbol;
        //                }
        //                else if (char.IsLetter(arrInput[i]) && char.IsUpper(arrInput[i]))
        //                {
        //                    int symbol = arrInput[i];
        //                    while (key > 0)
        //                    {
        //                        symbol++;
        //                        key--;
        //                        if (symbol == 91)
        //                        {
        //                            symbol = 65;
        //                        }

        //                    } //counter
        //                    newSymbol = (char)symbol;
        //                }
        //                else if (arrInput[i] == ':')
        //                {
        //                    newSymbol = '@';
        //                }
        //            } // encrypt
        //            encript += newSymbol;
        //        }
        //        Console.WriteLine($"Successful encryption: {encript}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid input!");
        //    }
    }
}
