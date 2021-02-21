using System;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace Ex_8._Increase_Minion_Age
{
    class Program
    {
        const string SqlConnectionString = @"Server=.\SQLEXPRESS;Integrated Security=true;Database=MinionsDB";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            int[] minionIDs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string updateMinionsQuery = @"UPDATE Minions
                                        SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                        WHERE Id = @Id";

            foreach (var id in minionIDs)
            {            
                using var sqlCommmand = new SqlCommand(updateMinionsQuery, connection);
                sqlCommmand.Parameters.AddWithValue(@"Id", id);
                sqlCommmand.ExecuteNonQuery();

            }

            var selectMinions = @"SELECT Name, Age FROM Minions";

            using var selectCommand = new SqlCommand(selectMinions, connection);

            using var reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} {reader[1]}");
            }

        }
    }
}
