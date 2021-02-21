﻿using System;
using Microsoft.Data.SqlClient;

namespace Ex_2._Villain_Names
{
    class Program
    {
        const string SqlConnectionString = @"Server=.\SQLEXPRESS;Integrated Security=true;Database=MinionsDB";
        static void Main(string[] args)
        {

            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            string query = @"SELECT [Name], COUNT(mv.MinionID)
	                       FROM Villains AS v
	                       JOIN MinionsVillains AS mv On mv.MinionID = v.Id
	                       GROUP BY v.Id, v.[Name]";
	                       //HAVING COUNT(mv.MinionID) > 3";

            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var name = reader[0];
                        var count = reader[1];

                        Console.WriteLine($"{name} - {count}");
                        
                    }
                    
                }
               
            
            }




        }
    }
}
