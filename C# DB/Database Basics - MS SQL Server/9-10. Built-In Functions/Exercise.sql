-- Problem 1. FIND NAMES OF ALL EMPLOYEES BY FIRST NAME
USE SoftUni

SELECT FirstName ,LastName
	FROM Employees
	WHERE FirstName LIKE 'SA%'


-- Problem 2. FIND NAMES OF ALL EMPLOYEES BY LAST NAME
SELECT FirstName, LastName
	FROM Employees
	WHERE LastName LIKE '%ei%'

-- Problem 3. FIND NAMES OF ALL EMPLOYEES
SELECT FirstName
	FROM Employees
	WHERE DepartmentID IN (3, 10) AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

-- Problem 4. FIND ALL EMPLOYEES EXCEPT ENGINEERS
SELECT FirstName, LastName
	FROM Employees
	WHERE JobTitle NOT LIKE '%engineer%'

-- Problem 5. FIND TOWNS WITH NAME LENGTH
SELECT [Name]
	FROM Towns
	WHERE LEN([Name]) IN (5, 6)
	ORDER BY [Name] ASC

-- Problem 6. FIND TOWNS STARTING WITH
SELECT TownID, [Name]
	FROM Towns
	WHERE [Name] LIKE '[MKBE]%'
	ORDER BY [Name] ASC

-- Problem 7. FIND TOWNS NOT STARTING WITH
SELECT TownID, [Name]
	FROM Towns
	WHERE [Name] NOT LIKE '[RBD]%'
	ORDER BY [Name] ASC

-- Problem 8. CREATE VIEW EMPLOYEES HIRED AFTER 2000 YEAR
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
	FROM Employees
	WHERE DATEPART(YEAR, HireDate) > 2000

-- Problem 9. LENGTH OF LAST NAME
SELECT FirstName, LastName
	FROM Employees
	WHERE LEN(LastName) = 5

-- Problem 10. RANK EMPLOYEES BY SALARY
SELECT EmployeeID, FirstName, LastName, Salary,
	  DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
	ORDER BY Salary DESC

-- Problem 11. FIND ALL EMPLOYEES WITH RANK 2
SELECT * FROM
(
    SELECT EmployeeID, FirstName, LastName, Salary,
    	  DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
    FROM Employees
    WHERE Salary BETWEEN 10000 AND 50000
) AS RankedTable
	WHERE RankedTable.[Rank] = 2
	ORDER BY Salary DESC

-- Problem 12. COUNTRIES HOLDING 'A' 3 OR MORE TIMES
USE Geography

SELECT CountryName AS [Country Name], IsoCode AS [ISO Code]
	FROM Countries
	WHERE CountryName LIKE '%a%a%a%'
	ORDER BY IsoCode

-- Problem 13. MIX OF PEAK AND RIVER NAMES
SELECT PeakName, RiverName,
	LOWER(LEFT (PeakName, LEN(PeakName) - 1) + RiverName ) AS Mix
	FROM Peaks, Rivers
	WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
	ORDER BY Mix

-- Problem 14. GAMES FROM 2011 AND 2012 YEAR
USE Diablo 

SELECT TOP 50 [Name],
	FORMAT([Start], 'yyyy-MM-dd') AS [Start]
	FROM Games
	WHERE DATEPART(YEAR, [Start]) IN (2011, 2012) -- OR
	-- WHERE DATEPART(YEAR, [Start]) BETWEEN 2011 AND 2012
	ORDER BY [Start], [Name]

-- Problem 15. USER EMAIL PROVIDERS
SELECT Username,
	SUBSTRING(Email, CHARINDEX('@', Email, 1) + 1, LEN(Email)) AS [Email Provider]
	FROM Users
	ORDER BY [Email Provider] ASC, Username ASC

-- Problem 16.  GET USERS WITH IP ADDRESS LIKE PATTERN
SELECT Username, IpAddress AS [IP Address] 
	FROM Users
	WHERE IpAddress LIKE '___.1%.%.___'
	ORDER BY Username

-- Problem 17. SHOW ALL GAMES WITH DURATION AND PART OF THE DAY
SELECT [Name] AS Game
      ,[Part of the Day] = 
            CASE 
                WHEN DATEPART(HOUR, Start) < 12 THEN 'Morning'
                WHEN DATEPART(HOUR, Start) < 18 THEN 'Afternoon'
                ELSE 'Evening'
            END
      ,Duration =
            CASE
                WHEN Duration <= 3 THEN 'Extra Short'
                WHEN Duration <= 6 THEN 'Short'
                WHEN Duration > 6 THEN 'Long'
                ELSE 'Extra Long'
            END
FROM Games
ORDER BY Game, Duration, [Part of the Day]

-- Problem 18. ORDERS TABLE
USE Orders

SELECT ProductName, OrderDate,
      DATEADD(DAY, 3, OrderDate) AS [Pay Due],
      DATEADD(MONTH, 1, OrderDate) AS [Deliver Due] 
FROM Orders

-- Problem 19. PEOPLE TABLE
CREATE TABLE People (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
    Birthdate DATETIME NOT NULL
)

INSERT INTO People VALUES
     ('Victor', '2000-12-07')
    ,('Steven', '1992-09-10')
    ,('Stephen', '1910-09-19')
    ,('John', '2010-01-06')

SELECT [Name],
    DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
    DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
    DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
    DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People



