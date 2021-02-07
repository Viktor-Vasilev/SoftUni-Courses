CREATE DATABASE Bakery
USE Bakery

-- SECTION 1 - DDL

-- Problem 1 Database Design

CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender CHAR CHECK(Gender IN ('M', 'F')),
	Age INT CHECK(Age >= 0),
	PhoneNumber CHAR(10) CHECK(LEN(PhoneNumber) = 10),
	CountryId INT CHECK(CountryId >= 0) FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE,
	[Description] NVARCHAR(250),
	Recipe NVARCHAR(MAX),
	Price DECIMAL (15,2) CHECK(Price >= 0)
)

CREATE TABLE Feedbacks
(
	Id INT PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(250),
	Rate DECIMAL (10,2) CHECK(Rate BETWEEN 0 AND 10),
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
)

CREATE TABLE Distributors
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE,
	AddressText NVARCHAR(30),
	Summary NVARCHAR(200),
	CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30),
	[Description] NVARCHAR(200),
	OriginCountryId INT  FOREIGN KEY REFERENCES Countries(Id),
	DistributorId INT  FOREIGN KEY REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
	ProductId INT FOREIGN KEY REFERENCES Products(Id) NOT NULL,
	IngredientId INT FOREIGN KEY REFERENCES Ingredients(Id) NOT NULL

	CONSTRAINT PK_ProductIngredient PRIMARY KEY(ProductId, IngredientId)
)


-- SECTION 2 - DML


-- Problem 2  - Insert
INSERT INTO Distributors ([Name], CountryId, AddressText, Summary) VALUES
('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling'),
('Congress Title',	13,	'58 Hancock St', 'Customer loyalty'),
('Kitchen People',	1,	'3 E 31st St #77', 'Triple-buffered stable delivery'),
('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO Customers (FirstName, LastName, Age, Gender, PhoneNumber, CountryId) VALUES
('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
('Kendra', 'Loud', 22,'F', '0063631526', 11),
('Lourdes', 'Bauswell',	50, 'M', '0139037043', 8),
('Hannah', 'Edmison',18, 'F', '0043343686',	1),
('Tom', 'Loeza', 31,'M', '0144876096', 23),
('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
('Hiu', 'Portaro', 25, 'M',	'0068277755', 16),
('Josefa', 'Opitz',	43, 'F', '0197887645', 17)



-- Problem 3 - Update
UPDATE Ingredients
	SET DistributorId = 35
		WHERE [Name] IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
	SET OriginCountryId = 14
		WHERE OriginCountryId = 8


-- Problem 4 - Delete
DELETE FROM Feedbacks
	WHERE CustomerId = 14

DELETE FROM Feedbacks
	WHERE ProductId = 5

-- SECTION 3 - Querying

-- Problem 5 - Products By Price
SELECT [Name], Price, [Description]
	FROM Products
	ORDER BY Price DESC, [Name] ASC

-- Problem 6 - Negative Feedback
SELECT f.ProductId, f.Rate, f.[Description], f.CustomerId, c.Age, c.Gender
	FROM Feedbacks AS f
		JOIN Customers AS c ON c.Id = f.CustomerId
		WHERE f.Rate < 5.00
		ORDER BY f.ProductId DESC, f.Rate ASC 

-- Problem 7 - Customers without Feedback
--SELECT c.FirstName + ' ' + c.LastName AS [CustomerName], c.PhoneNumber, c.Gender
--	FROM Customers AS c
--	LEFT JOIN Feedbacks AS f on f.CustomerId = c.Id
--	WHERE f.Id IS NULL
-- ONLY 3 FROM 6   ????????????

SELECT CONCAT(FirstName, ' ', LastName) AS CustomerName, c.PhoneNumber, c.Gender
	FROM Customers AS c
	LEFT JOIN Feedbacks AS f on f.CustomerId = c.Id
	WHERE f.Id IS NULL


-- Problem 8 - Customers by Criteria
SELECT FirstName, Age, PhoneNumber
	FROM Customers AS c
	JOIN Countries AS co ON c.CountryId = co.Id
WHERE (Age >= 21 AND FirstName LIKE '%an%') OR (RIGHT(PhoneNumber, 2) = 38 AND [Name] != 'Greece')
ORDER BY FirstName ASC, Age DESC

-- Problem 9 - Middle Range Distributors
SELECT d.[Name] AS [DistributorName], i.[Name] AS [IngredientName], p.[Name] AS [ProductName], AVG(f.[Rate]) AS [AverageRate]
FROM Distributors AS d
	JOIN Ingredients AS i ON d.Id = i.DistributorId
	JOIN ProductsIngredients AS pin ON i.Id = pin.IngredientId
	JOIN Products AS p ON pin.ProductId = p.Id
	JOIN Feedbacks AS f ON p.Id = f.ProductId
GROUP BY d.[Name], i.[Name], p.[Name]
HAVING AVG(f.[Rate]) BETWEEN 5 AND 8
ORDER BY [DistributorName] ASC, [IngredientName] ASC, [ProductName] ASC

-- Problem 10 - Country Representative
SELECT [CountryName], [DisributorName]
FROM (
        SELECT [CountryName],
               [DisributorName],
               [Count],
               DENSE_RANK() OVER (PARTITION BY [CountryName] ORDER BY [Count] DESC) AS [Rank]
        FROM (
                SELECT c.[Name] AS [CountryName], d.[Name] AS [DisributorName], COUNT(d.[Name]) AS [Count]
                FROM Countries AS c
                JOIN Distributors AS d ON c.[Id] = d.[CountryId]
                JOIN Ingredients AS i ON d.[Id] = i.[DistributorId]
                GROUP BY c.[Name], d.[Name]
            ) AS [GroupedQuery]
      ) AS [DenseRankQuery]
WHERE [Rank] = 1
ORDER BY [CountryName] ASC, [DisributorName] ASC


--SECTION 4 - Programmability

-- Problem 11 - Customers With Countries
CREATE VIEW v_UserWithCountries AS
SELECT CONCAT(FirstName, ' ', LastName) AS CustomerName, c.Age, c.Gender, co.Name AS CountryName
	FROM Customers AS c
	LEFT JOIN Countries as co ON co.Id = c.CountryId

SELECT TOP 5 *
  FROM v_UserWithCountriess
 ORDER BY Age


-- Problem 12 - Delete Products

