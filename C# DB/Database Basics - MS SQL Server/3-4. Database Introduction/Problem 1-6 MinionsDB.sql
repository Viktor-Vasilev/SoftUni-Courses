/* PROBLEM 1 - CREATE DATABASE */

CREATE DATABASE Minions

/* Problem 2 - CREATE TABLES */
CREATE TABLE Minions
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(30),
	Age INT
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR (50)
)

/* Problem 3 - ALTER MINIONS TABLE */
ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)

/* Problem 4 - INSERT RECORDS IN BOTH TABLES */
INSERT INTO Towns (Id, Name) Values
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions (Id, Name, Age, TownId) VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

SELECT * FROM Towns
SELECT * FROM Minions

/* Problem 5 - DELETE TABLE MINIONS */
DELETE FROM Minions

/* Problem 6 - DROP ALL TABLES */
DROP TABLE Minions
DROP TABLE Towns