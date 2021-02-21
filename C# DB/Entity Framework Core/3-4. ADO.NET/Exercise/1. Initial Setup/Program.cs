﻿using System;
using Microsoft.Data.SqlClient;

namespace Ex_1._Initial_Setup
{
    public class Program
    {
        //const string SqlConnectionString = @"Server=.\SQLEXPRESS;Integrated Security=true;Database=master";
        const string SqlConnectionString = @"Server=.\SQLEXPRESS;Integrated Security=true;Database=MinionsDB";


        public static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            //1. Create database --------------------------------------------------

            //string createDatabase = "CREATE DATABASE MinionsDB";
            //using (var command = new SqlCommand(createDatabase, connection))
            //{
            //    command.ExecuteNonQuery();
            //}

            //2. Create tables -----------------------------------------------------

            //var createTableStatement = GetCreateTableStatements();

            //foreach (var query in createTableStatement)
            //{
            //    ExecuteNonQueryd(connection, query);
            //}

            //3. Insert into tables ------------------------------------------------

            var insertStatements = GetInsertDataStatements();

            foreach (var query in insertStatements)
            {
                ExecuteNonQueryd(connection, query);
            }

        }

        private static void ExecuteNonQueryd(SqlConnection connection, string query)
        {
            using var command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        private static string[] GetCreateTableStatements()
        {
            var result = new string[]
            {
             "CREATE TABLE Countries(Id INT PRIMARY KEY,[Name] VARCHAR(50))",
             "CREATE TABLE Towns(Id INT PRIMARY KEY,[Name] VARCHAR(50),CountryCode INT FOREIGN KEY REFERENCES Countries(Id))",
             "CREATE TABLE Minions(Id INT PRIMARY KEY,[Name] VARCHAR(50),Age INT,	TownId INT FOREIGN KEY REFERENCES Towns(Id))",
             "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY,[Name] VARCHAR(50))",
             "CREATE TABLE Villains(	Id INT PRIMARY KEY,[Name] VARCHAR(50),	EvilnessFactors INT FOREIGN KEY REFERENCES EvilnessFactors(Id))",
             "CREATE TABLE MinionsVillains(MinionID INT FOREIGN KEY REFERENCES Minions(Id),	VillainId INT FOREIGN KEY REFERENCES Villains(Id) CONSTRAINT PK_MinionsVillains PRIMARY KEY(MinionId, VillainId))"
            };

            return result;
        }

        private static string[] GetInsertDataStatements()
        {
            var result = new string[]
            {
             "INSERT INTO Countries (Id, [Name]) VALUES (1, 'Bulgaria'), (2, 'Norway'), (3, 'Cyprus'), (4, 'Greece'), (5, 'UK')",
             "INSERT INTO Towns (Id, [Name], CountryCode) VALUES (1, 'Plovdiv', 1), (2, 'Oslo', 2), (3, 'Larnaka', 3), (4, 'Athens', 4), (5, 'London', 5)",
             "INSERT INTO Minions VALUES (1, 'Stoyan', 12, 1), (2, 'George', 22, 2), (3, 'Ivan', 25, 3), (4, 'Kiro', 35, 4), (5, 'Niki', 25, 5)",
             "INSERT INTO EvilnessFactors VALUES (1, 'super good'), (2, 'good'), (3, 'bad'), (4, 'evil'), (5, 'super evil')",
             "INSERT INTO Villains VALUES(1, 'Gru', 1), (2, 'Ivo', 2), (3, 'Teo', 3), (4, 'Sto', 4), (5, 'Pro', 5)",
             "INSERT INTO MinionsVillains VALUES (1, 1), (2, 2), (3, 3), (4, 4), (5, 5)"
            };

            return result;
        }

    }
}
