using System;
using Microsoft.Data.SqlClient;

namespace Ex_6._Remove_Villain
{
    class Program
    {
        const string SqlConnectionString = @"Server=.\SQLEXPRESS;Integrated Security=true;Database=MinionsDB";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            int villainId = int.Parse(Console.ReadLine());


            string evilNameQuery = "SELECT Name FROM Villains WHERE Id = @villainId";
            using var sqlCommmand = new SqlCommand(evilNameQuery, connection);
            sqlCommmand.Parameters.AddWithValue(@"villainId", villainId);
            var name = (string)sqlCommmand.ExecuteScalar();

            if (name == null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }



            var deleteMinionsVillainsQuery = @"DELETE FROM MinionsVillains 
                                             WHERE VillainId = @villainId";
            var sqlDeleteMinionsVillainsCommand = new SqlCommand(deleteMinionsVillainsQuery, connection);
            sqlDeleteMinionsVillainsCommand.Parameters.AddWithValue(@"villainId", villainId);
            var affectedRows = sqlDeleteMinionsVillainsCommand.ExecuteNonQuery();



            var deleteVillainQuery = @"DELETE FROM Villains
                                     WHERE Id = @villainId";
            var sqlDeleteVillainsCommand = new SqlCommand(deleteVillainQuery, connection);
            sqlDeleteVillainsCommand.Parameters.AddWithValue(@"villainId", villainId);
            sqlDeleteVillainsCommand.ExecuteNonQuery();

            Console.WriteLine($"{name} was deleted.");
            Console.WriteLine($"{affectedRows} minions were released.");

        }
    }
}
