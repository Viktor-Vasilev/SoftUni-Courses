/* Problem 13 - MOVIES DATABASE */
CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors 
(
	Id INT PRIMARY KEY,
	DirectorName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Genres 
(
	Id INT PRIMARY KEY,
	GenreName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Categories 
(
	Id INT PRIMARY KEY,
	CategoryName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Movies 
(
	 Id INT PRIMARY KEY,
	 Title VARCHAR(100) NOT NULL,
	 DirectorId INT NOT NULL,
	 CopyrightYear INT,
	 [Length] TIME,
	 GenreId INT NOT NULL,
	 CategoryId INT  NOT NULL,
	 Rating DECIMAL(2,1),
	 Notes VARCHAR(MAX)
)

INSERT INTO Directors (Id, DirectorName) VALUES 
	(1, 'Ivan Ivanov'),
	(2, 'Vasil Vasilev'),
	(3, 'Jivotnoto Jelqzkov'),
	(4, 'Radul Bratoev'),
	(5, 'Stefan Stoev')

INSERT INTO Genres (Id, GenreName)VALUES
	(1, 'Boza'),
	(2, 'Fantasy'),
	(3, 'Killer'),
	(4, 'Serial'),
	(5, 'Comedy')



INSERT INTO Categories (Id, CategoryName) VALUES
	(1, 'AA'),
	(2, 'BB'),
	(3, 'CC'),
	(4, 'DD'),
	(5, 'EE')

INSERT INTO Movies (Id, Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating) VALUES
	 (1, 'Rambo 1', 1, 1976, '1:35:00', 2, 5, 9.1),
	 (2, 'Rambo 2', 2, 1978, '2:15:00', 1, 4, 7.2),
	 (3, 'Rambo 3', 3, 1980, '1:37:00', 3, 3, 6.3),
	 (4, 'Rambo 4', 4, 1982, '1:16:00', 5, 2, 5.7),
	 (5, 'Rambo 5', 5, 1985, '3:03:00', 5, 1, 4.0)
