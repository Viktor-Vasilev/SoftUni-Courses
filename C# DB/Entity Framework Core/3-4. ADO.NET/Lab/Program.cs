using System;
using Microsoft.Data.SqlClient;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(
                @"Server=.\SQLEXPRESS;Integrated Security=true;Database=SoftUni"))
            {
                connection.Open();

                //// Execute NonQuery
                //SqlCommand sqlCommand = new SqlCommand("UPDATE Employees SET Salary = Salary + 0.12 WHERE FirstName LIKE 'N%'", connection);

                //var rowsAffected = sqlCommand.ExecuteNonQuery();

                //Console.WriteLine(rowsAffected);



                //// Execute Scalar
                //SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);

                //var rowsAffected = (int)sqlCommand.ExecuteScalar();

                //Console.WriteLine(rowsAffected);



                // Execite Reader
                //var sqlCommand = new SqlCommand
                //    ("SELECT * FROM Employees ORDER BY [FirstName]", connection);

                //using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                //{
                //    while (sqlDataReader.Read())
                //    {
                //        Console.WriteLine(sqlDataReader["FirstName"]);
                //    }
                //}

                // SQL Injection
                var sqlCommand = new SqlCommand(@"", connection);

                var sqlDataReader = sqlCommand.ExecuteReader();



                // CHEAT SHEET

                //connectionString
                
                //- SqlConnection
                //    - openSqlConnection
                
                //- ExecuteNonQuery
                //    - Insert, Delete, Update
                
                //- Execute Scalar
                //    - If The select query returns only ONE record
                
                //- ExecuteReader
                //    - If the select query returns more than one record
                
                //command.Parameters.AddWithValue("villainId", villainId);
                


            }
        }
    }
}
