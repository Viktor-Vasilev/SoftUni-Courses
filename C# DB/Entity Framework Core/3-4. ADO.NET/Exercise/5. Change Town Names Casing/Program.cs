﻿using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Ex_5._Change_Town_Names_Casing
{
    class Program
    {
        const string SqlConnectionString = @"Server=.\SQLEXPRESS;Integrated Security=true;Database=MinionsDB";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            string countryName = Console.ReadLine();

            string updateTownNamesQuery = @"UPDATE Towns
                                          SET Name = UPPER(Name)
                                          WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

            string selectTownNamesQuery = @"SELECT t.Name 
                                          FROM Towns as t
                                          JOIN Countries AS c ON c.Id = t.CountryCode
                                          WHERE c.Name = @countryName";

            using var updateCommand = new SqlCommand(updateTownNamesQuery, connection);


            updateCommand.Parameters.AddWithValue("@countryName", countryName);

            var affectedRows =  updateCommand.ExecuteNonQuery();

            if (affectedRows == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                Console.WriteLine($"{affectedRows} town names were affected. ");

                using var selectCommand = new SqlCommand(selectTownNamesQuery, connection);
                selectCommand.Parameters.AddWithValue("@countryName", countryName);

                using (var reader = selectCommand.ExecuteReader())
                {
                    var towns = new List<string>();

                    while (reader.Read())
                    {
                        towns.Add((string)reader[0]);
                    }

                    Console.WriteLine($"[{string.Join(", ", towns)}]");
                }


            }

        }
    }
}
