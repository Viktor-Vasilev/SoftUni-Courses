using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Ex_7._Print_All_Minion_Names
{

    class Program
    {
        const string SqlConnectionString = @"Server=.\SQLEXPRESS;Integrated Security=true;Database=MinionsDB";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            var minionsQuery = "SELECT Name FROM Minions";

            using var selectCommand = new SqlCommand(minionsQuery, connection);

            var minions = new List<string>();

            using (var reader = selectCommand.ExecuteReader())
            {
                minions.Add("Odd"); // make minions odd number

                while (reader.Read())
                {
                    minions.Add((string)reader[0]);
                }

                int counter = 0;

                for (int i = 0; i < minions.Count / 2; i++)
                {
                    Console.WriteLine(minions[0 + counter]);
                    Console.WriteLine(minions[minions.Count - 1 - counter]);
                    counter++;
                }

                if (minions.Count % 2 != 0)
                {
                    Console.WriteLine(minions[minions.Count / 2]);
                }


                //Console.WriteLine($"[{string.Join(", ", minions)}]");
            }

        }
    }
}
